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
        readonly Image<Rgba32> image;
        public PNGDiploma(Image<Rgba32> img) => image = img;
        public void Save(string Path) => image.Save(Path);
    }

    public class PNGGenerator : IDiplomaGenerator
    {
        public IDiploma Generate(Template template)
        {
            var image = Image.Load(template.Stream);
            foreach (var field in template.Fields)
            {
                (var xOffset, var yOffset, var width, var height) = field;
                var x = (int)(xOffset * image.Width);
                var y = (int)(yOffset * image.Height);
                var h = (int)(height * image.Height);
                var w = (int)(width * image.Width);
                var text = field.Value;
                var font = SystemFonts.CreateFont("Arial", 72);

                var size = TextMeasurer.Measure(text, new RendererOptions(font));

                var scalingFactor = Math.Min(w / size.Width, h / size.Height);

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

            return new PNGDiploma(image);
        }
    }
}
