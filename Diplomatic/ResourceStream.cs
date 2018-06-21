using System;
using System.IO;
using Diplomatic.Core;
namespace Diplomatic
{
    public class ResourceStream : ITemplateStream
    {
        public ResourceStream()
        {
        }

        public Stream Stream => new MemoryStream(new byte[] { 0x1, 0x2 }
                                                );

        public string FilePath => "Halloi";

        public bool IsValid => true;
    }
}
