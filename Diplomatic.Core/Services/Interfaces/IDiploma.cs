using System.IO;

namespace Diplomatic.Core
{
    public interface IDiploma
    {
        Stream GetResult();
        void Save(string Path);
    }
}
