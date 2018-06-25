using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Diplomatic.Utils
{
    using Interfaces;

    public class ResourceLoader : IResourceLoader
    {
        public string LoadText(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid resource name.", nameof(name));
            }

            Stream stream = GetResourceStream(name, ResourceType.Text);

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        public async Task<string> LoadTextAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid resource name.", nameof(name));
            }

            Stream stream = GetResourceStream(name, ResourceType.Text);

            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public ImageSource LoadImage(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid resource name.", nameof(name));
            }

            Stream stream = GetResourceStream(name, ResourceType.Image);

            return ImageSource.FromStream(() => stream);
        }

        public IEnumerable<byte> LoadBinary(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid resource name.", nameof(name));
            }

            Stream stream = GetResourceStream(name, ResourceType.Binary);

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public async Task<IEnumerable<byte>> LoadBinaryAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid resource name.", nameof(name));
            }

            Stream stream = GetResourceStream(name, ResourceType.Binary);

            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        private enum ResourceType
        {
            Image,
            Text,
            Binary
        }

        private Stream GetResourceStream(string name, ResourceType type)
        {
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(ResourceLoader)).Assembly;

            string path = $"{nameof(Diplomatic)}.Assets";

            switch (type)
            {
                case ResourceType.Text:
                    path += $".{name}";
                    break;

                case ResourceType.Image:
                    path += $".Images.{name}";
                    break;

                case ResourceType.Binary:
                    path += $".{name}";
                    break;

                default:
                    throw new ArgumentException("Invalid resource type.", nameof(type));
            }

            Stream stream = assembly.GetManifestResourceStream(path);

            if (stream == null)
            {
                throw new FileNotFoundException($"Resource not found: {path}", nameof(name));
            }

            return stream;
        }
    }
}
