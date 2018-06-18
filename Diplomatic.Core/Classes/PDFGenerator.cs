using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Your diploma is ready";
            document.Info.Author = "Diplomatic 2018";
            document.PageLayout = PdfPageLayout.SinglePage;

            XPdfForm originalPdf = XPdfForm.FromFile(template.FilePath);

            PdfPage page = document.AddPage();
            page.Height = originalPdf.PixelHeight;
            page.Width = originalPdf.PixelWidth;

            XGraphics gfx = XGraphics.FromPdfPage(page);

            gfx.DrawImage(originalPdf, new XRect(0, 0, page.Width, page.Height));

            XFont font = new XFont("Comic Sans MS", 20, XFontStyle.Bold);
            foreach (var field in template.Fields)
            {
                (int x, int y, int h, int w) = field;
                var boundingBox = new XRect(x, y, w, h);
                gfx.DrawString(field.Value, font, XBrushes.Black, boundingBox, XStringFormats.BottomCenter);
            }

            return new PDFDiploma(document);
        }
    }
}
