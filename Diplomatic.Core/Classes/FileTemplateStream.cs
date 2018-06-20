using System.IO;

namespace Diplomatic.Core
{
    public class FileStream : ITemplateStream
    {
        public Stream Stream => File.OpenRead(FilePath);
        public string FilePath { get; }
        public bool IsValid => File.Exists(FilePath);

        public FileStream(string path)
        {
            // TODO: Fix ugly hack
            FilePath = Path.GetFullPath("..\\Resources\\" + path);
        }
    }
}
