using Diplomatic.Core;
using Moq;
using System.IO;
using Xunit;

namespace Diplomatic.Tests
{
    public class TemplateTest
    {
        readonly Template subject;

        public TemplateTest()
        {
            var mockedStream = new Mock<ITemplateStream>();
            mockedStream.Setup(IsValid => true);
            subject = new Template("Test template", mockedStream.Object, new Field[] { });
        }

        [Fact]
        public void NotValidWithoutFields()
        {
            Assert.False(subject.IsValid);
        }
    }
}
