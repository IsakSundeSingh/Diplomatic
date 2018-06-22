using System.Drawing;

namespace Diplomatic.Core
{
    public class PDFDiploma : IDiploma
    {
        public void Save(string path)
        {
            return;
        }
    }

    public class PDFGenerator : IDiplomaGenerator
    {
        public IDiploma Generate(Template template)
        {
            return new PDFDiploma();
        }
    }
}
