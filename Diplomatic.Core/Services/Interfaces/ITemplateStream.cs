using System.IO;

namespace Diplomatic.Core
{
    public interface ITemplateStream
    {
        Stream Stream { get; }
        string FilePath { get; }
        bool IsValid { get; }
    }
}
