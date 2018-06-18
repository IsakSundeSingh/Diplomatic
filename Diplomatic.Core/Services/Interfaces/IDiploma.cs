using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Diplomatic.Core
{
    public interface IDiploma
    {
        void Save(string Path);
    }
}
