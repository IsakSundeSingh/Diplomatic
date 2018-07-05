using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Diplomatic.Tests
{
    using Utils;

    public class ResourceLoaderTest
    {
        public class LoadText
        {

            [Fact]
            public void CanLoadText()
            {
                // TODO: Fix dependency on actual file existence
                string resource = "Images.test.png";

                var loader = new ResourceLoader();
                string result = loader.LoadText(resource);

                Assert.False(string.IsNullOrEmpty(result));
            }

            [Fact]
            public void ThrowsOnInvalidName()
            {
                string resource = "";

                var loader = new ResourceLoader();

                Assert.Throws<ArgumentException>(() => loader.LoadText(resource));
            }

            [Fact]
            public void ThrowsOnNonExistentResource()
            {
                string resource = "oogabooga";

                var loader = new ResourceLoader();

                Assert.Throws<FileNotFoundException>(() => loader.LoadText(resource));
            }
        }

        public class LoadTextAsync
        {
            [Fact]
            public async Task CanLoadText()
            {
                // TODO: Fix dependency on actual file existence
                string resource = "Images.test.png";
                var loader = new ResourceLoader();

                string result = await loader.LoadTextAsync(resource);

                Assert.False(string.IsNullOrEmpty(result));
            }

            [Fact]
            public async Task ThrowsOnInvalidName()
            {
                string resource = "";
                var loader = new ResourceLoader();
                await Assert.ThrowsAsync<ArgumentException>(async () => await loader.LoadTextAsync(resource));
            }

            [Fact]
            public async Task ThrowsOnNonExistentResource()
            {
                string resource = "I ain't even real";
                var loader = new ResourceLoader();

                await Assert.ThrowsAsync<FileNotFoundException>(async () => await loader.LoadTextAsync(resource));
            }
        }

        public class LoadImage
        {

            [Fact]
            public void CanLoadImage()
            {
                // TODO: Fix dependency on actual file existence
                string resource = "test.png";
                var loader = new ResourceLoader();

                loader.LoadImage(resource);

                // Nothing should have been thrown
            }

            [Fact]
            public void ThrowsOnInvalidName()
            {
                string resource = "";
                var loader = new ResourceLoader();

                Assert.Throws<ArgumentException>(() => loader.LoadImage(resource));
            }

            [Fact]
            public void ThrowsOnNonExistentResource()
            {
                string resource = "i dont exiiist";
                var loader = new ResourceLoader();

                Assert.Throws<FileNotFoundException>(() => loader.LoadImage(resource));
            }
        }

        public class LoadBinary
        {
            [Fact]
            public void CanLoadBinary()
            {
                // TODO: Fix dependency on actual file existence
                string resource = "Images.test.png";
                var loader = new ResourceLoader();

                byte[] bytes = loader.LoadBinary(resource).ToArray();

                Assert.True(bytes.Length > 0);
            }

            [Fact]
            public void ThrowsOnInvalidName()
            {
                string resource = "";
                var loader = new ResourceLoader();

                Assert.Throws<ArgumentException>(() => loader.LoadBinary(resource));
            }

            [Fact]
            public void ThrowsOnNonExistentResource()
            {
                string resource = "Bi-nary";
                var loader = new ResourceLoader();

                Assert.Throws<FileNotFoundException>(() => loader.LoadBinary(resource));
            }
        }
        public class LoadBinaryAsync
        {
            [Fact]
            public async Task CanLoadBinary()
            {
                // TODO: Fix dependency on actual file existence
                string resource = "Images.test.png";
                var loader = new ResourceLoader();

                byte[] bytes = (await loader.LoadBinaryAsync(resource)).ToArray();

                Assert.True(bytes.Length > 0);
            }

            [Fact]
            public async Task ThrowsOnInvalidName()
            {
                string resource = "";
                var loader = new ResourceLoader();

                await Assert.ThrowsAsync<ArgumentException>(async () => await loader.LoadBinaryAsync(resource));
            }

            [Fact]
            public async Task ThrowsOnNonExistentResource()
            {
                string resource = "Bi-nary";
                var loader = new ResourceLoader();

                await Assert.ThrowsAsync<FileNotFoundException>(async () => await loader.LoadBinaryAsync(resource));
            }
        }

    }
}
