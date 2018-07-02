using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Drawing;
using SixLabors.ImageSharp.Processing.Text;
using SixLabors.ImageSharp.Processing.Transforms;
using SixLabors.Primitives;

namespace Diplomatic.Core
{
    public class PNGDiploma : IDiploma
    {
        public readonly byte[] imageData;
        public PNGDiploma(byte[] image) => imageData = image;
        public Stream GetResult() => new MemoryStream(imageData);
        public void Save(string Path)
        {
            return;
        }
    }

    public class PNGGenerator : IDiplomaGenerator
    {
        public IDiploma Generate(Template template, byte[] imageData)
        {
            var image = Image.Load(imageData);
            foreach (Field field in template.Fields)
            {
                (int x, int y, int w, int h) = GetResized(image, field);
                string text = field.Value;
                Font font = SystemFonts.CreateFont("Arial", 72);

                SizeF size = TextMeasurer.Measure(text, new RendererOptions(font));

                float scalingFactor = Math.Min(w / size.Width, h / size.Height);

                var scaledFont = new Font(font, scalingFactor * font.Size);

                var textGraphicOptions = new TextGraphicsOptions(true)
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom
                };
                var center = new Point(x + (w / 2), y + (h / 2));

                var color = Rgba32.FromHex(field.Color);
                image.Mutate(img => img
                        .DrawText(textGraphicOptions, text, scaledFont, color, center));
            }
            if (template.Signature != null && template.Signature.IsValid)
            {
                Field field = template.Signature;
                (int x, int y, int w, int h) = GetResized(image, field);
                var sig = Image.Load(field.Value);
                sig.Mutate(img => img.Resize(w, h));
                var topLeft = new Point(x, y);
                var center = new Point(x + (w / 2), y + (h / 2));
                image.Mutate(img => img.DrawImage(sig, 1.0f, topLeft));
            }

            return new PNGDiploma(image.SavePixelData());
        }

        private (int x, int y, int w, int h) GetResized(Image<Rgba32> image, Field field)
        {
            (double xOffset, double yOffset, double width, double height) = field;
            int x = (int)(xOffset * image.Width);
            int y = (int)(yOffset * image.Height);
            int w = (int)(width * image.Width);
            int h = (int)(height * image.Height);
            return (x, y, w, h);
        }
    }
}
