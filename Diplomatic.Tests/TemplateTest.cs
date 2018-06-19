using Diplomatic.Core;
using Moq;
using System.IO;
using Xunit;

namespace Diplomatic.Tests
{
    public class TemplateTest
    {
        readonly IField[] ValidFields;
        readonly ITemplateStream ValidStream;
        Template subject;

        public TemplateTest()
        {
            var mockField = new Mock<IField>();
            mockField.Setup(field => field.IsValid).Returns(true);
            ValidFields = new IField[] { mockField.Object };

            var mockStream = new Mock<ITemplateStream>();
            mockStream.Setup(stream => stream.IsValid).Returns(true);
            ValidStream = mockStream.Object;
        }

        [Fact]
        public void ValidatesFieldsAreFilled()
        {
            subject = new Template("Template with filled fields", ValidStream, ValidFields);
            Assert.True(subject.IsValid);
        }

        [Fact]
        public void NotValidWithoutFields()
        {
            Template subject = new Template("Template with no fields", ValidStream, new Field[] { });
            Assert.False(subject.IsValid);
        }

        [Fact]
        public void NotValidWithoutStream()
        {
            var mockStream = new Mock<ITemplateStream>();
            mockStream.Setup(stream => stream.IsValid).Returns(false);
            var badStream = mockStream.Object;

            Template subject = new Template("Test template", badStream, ValidFields);

            Assert.False(subject.IsValid);
        }
    }
}
