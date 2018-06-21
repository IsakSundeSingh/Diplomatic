using Didstopia.PDFSharp.Drawing;
using Didstopia.PDFSharp.Pdf;
using System.Drawing;

namespace Diplomatic.Core
{
    public class PDFDiploma : IDiploma
    {
        PdfDocument document;
        public PDFDiploma(PdfDocument doc)
        {
            document = doc;
        }

        public void Save(string Path)
        {
            document.Save(Path);
        }
    }

    public class PDFGenerator : IDiplomaGenerator
    {
        public IDiploma Generate(Template template)
        {
            var document = new PdfDocument();
            document.Info.Title = template.TemplateName;
            document.Info.Author = "Diplomatic © 2018";
            document.PageLayout = PdfPageLayout.SinglePage;

            var originalPdf = XPdfForm.FromStream(template.Stream);

            var page = document.AddPage();
            page.Height = originalPdf.PixelHeight;
            page.Width = originalPdf.PixelWidth;

            var gfx = XGraphics.FromPdfPage(page);

            gfx.DrawImage(originalPdf, new XRect(0, 0, page.Width, page.Height));

            foreach (var field in template.Fields)
            {
                (var xOffset, var yOffset, var height, var width) = field;
                var x = (int)(xOffset * page.Width);
                var y = (int)(yOffset * page.Height);
                var h = (int)(height * page.Height);
                var w = (int)(width * page.Width);

                var fontName = "Comic Sans MS";
                var fontColor = "Black";
                var fontSize = (int)(h * 0.8);
                var font = new XFont(fontName, fontSize, XFontStyle.Bold);
                var brush = new XSolidBrush(XColor.FromArgb(0));
                var boundingBox = new XRect(x, y, w, h);
                gfx.DrawString(field.Value, font, brush, boundingBox, XStringFormats.BottomCenter);
            }

            return new PDFDiploma(document);
        }
    }
}
