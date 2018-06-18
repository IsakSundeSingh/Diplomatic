using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;

namespace Diplomatic.Core
{
    class testDiplom
    {
        public static void Main()
        {
            Field awardwinner = new Field("Name", 10, 10, 30, 30);
            Field date = new Field("Date", 20, 10, 30, 30);
            Field awardtype = new Field("Award", 20, 10, 30, 30);
            Field signature = new Field("Signature", 30, 10, 30, 30);

            Field[] fields = { awardwinner, date, awardtype, signature };

            Template template1 = new Template("./templates/template1.pdf", "template1", fields);

            string Json = Newtonsoft.Json.JsonConvert.SerializeObject(template1);
            Console.WriteLine($"{Json}");


            PDFhandler(template1, "Mads", DateTime.Today, "Hello", "Hello");
            string input = Console.ReadLine();

        }
        // Maybe change signature to operate as a PNG or something placed into the certificate, at a later time
        static void PDFhandler(Template template, string recipient, DateTime date, string award, string Signature)
        {
            PdfDocument outputDocument = new PdfDocument
            {
                PageLayout = PdfPageLayout.TwoPageLeft
            };

            // Set fonts and stuff for writing
            XFont font = new XFont("Comic Sans MS", 10, XFontStyle.Bold);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Near;
            format.LineAlignment = XLineAlignment.Far;
            XGraphics gfx;

            // Create new page and Set orientation

            PdfPage page1 = outputDocument.AddPage();
            page1.Orientation = PageOrientation.Landscape;
            gfx = XGraphics.FromPdfPage(page1);
            // Fetch PDF from out template and write graphics from template onto our "new" page
            XPdfForm templatedoc = XPdfForm.FromFile(template.FilePath);
            gfx.DrawImage(templatedoc, new XRect(0, 0, templatedoc.PointWidth, templatedoc.PointHeight));
            
            // Saving with new name
            const string filename = "new_diplom.pdf";
            outputDocument.Save(filename);
        }
    }

}


