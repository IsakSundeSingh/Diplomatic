using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplomatic.Utils.Interfaces
{
    internal interface IResourceLoader
    {
        string LoadText(string name);

        Task<string> LoadTextAsync(string name);

        ImageSource LoadImage(string name);

        IEnumerable<byte> LoadBinary(string name);

        Task<IEnumerable<byte>> LoadBinaryAsync(string name);
    }
}
