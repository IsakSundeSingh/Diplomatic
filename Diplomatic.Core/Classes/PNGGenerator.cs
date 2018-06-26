using System;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Text;
using SixLabors.Primitives;

namespace Diplomatic.Core
{
    public class PNGDiploma : IDiploma
    {
        public readonly Image<Rgba32> image;
        public PNGDiploma(Image<Rgba32> img) => image = img;
        public void Save(string Path) => image.Save(Path);
    }

    public class PNGGenerator : IDiplomaGenerator
    {
        public IDiploma Generate(Template template)
        {
            var image = Image.Load(template.ResourcePath);
            foreach (IField field in template.Fields)
            {
                (double xOffset, double yOffset, double width, double height) = field;
                int x = (int)(xOffset * image.Width);
                int y = (int)(yOffset * image.Height);
                int h = (int)(height * image.Height);
                int w = (int)(width * image.Width);
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
                var center = new PointF(x + (w / 2), y + (h / 2));

                image.Mutate(img => img
                        .DrawText(textGraphicOptions, text, scaledFont, Rgba32.Black, center));
            }
            if (template.Signature != null)
            {
                (double xOffset, double yOffset, double width, double height) = template.Signature;
                int x = (int)(xOffset * image.Width);
                int y = (int)(yOffset * image.Height);
                int h = (int)(height * image.Height);
                int w = (int)(width * image.Width);
                Font font = SystemFonts.CreateFont("Arial", 72);
                var center = new PointF(x + (w / 2), y + (h / 2));
                image.Mutate(img => img.DrawText("signature here", font, Rgba32.Red, center));
            }

            return new PNGDiploma(image);
        }
    }
}
