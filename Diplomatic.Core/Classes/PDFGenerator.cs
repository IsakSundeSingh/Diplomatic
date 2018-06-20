﻿using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            document.Info.Title = template.TemplateName;
            document.Info.Author = "Diplomatic © 2018";
            document.PageLayout = PdfPageLayout.SinglePage;

            XPdfForm originalPdf = XPdfForm.FromStream(template.Stream);

            PdfPage page = document.AddPage();
            page.Height = originalPdf.PixelHeight;
            page.Width = originalPdf.PixelWidth;

            XGraphics gfx = XGraphics.FromPdfPage(page);

            gfx.DrawImage(originalPdf, new XRect(0, 0, page.Width, page.Height));

            foreach (var field in template.Fields)
            {
                (int x, int y, int w, int h) = field;
                var fontName = "Comic Sans MS";
                var fontColor = "Black";
                var fontSize = (int)(h * 0.8);

                XFont font = new XFont(fontName, fontSize, XFontStyle.Bold);
                XSolidBrush brush = new XSolidBrush(XColor.FromArgb(Color.FromName(fontColor)));
                var boundingBox = new XRect(x, y, w, h);
                gfx.DrawString(field.Value, font, brush, boundingBox, XStringFormats.BottomCenter);
            }

            return new PDFDiploma(document);
        }
    }
}
