using Diplomatic.Core;
using Moq;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Xunit;

namespace Diplomatic.Tests
{
    public class TemplateTest
    {
        private readonly IField[] validFields;
        private Template subject;

        public TemplateTest()
        {
            var mockField = new Mock<IField>();
            mockField.Setup(field => field.IsValid).Returns(true);
            validFields = new IField[] { mockField.Object };
        }

        [Fact]
        public void ValidatesFieldsAreFilled()
        {
            subject = new Template("Template with filled fields", "name.png", validFields);
            Assert.True(subject.IsValid);
        }

        [Fact]
        public void NotValidWithoutFields()
        {
            subject = new Template("Template with no fields", "name.png", new Field[] { });
            Assert.False(subject.IsValid);
        }

        [Fact]
        public void DeserializesFromJSON()
        {
            string serialized = @"{
                ""ResourcePath"":""testFile.png"",
                ""TemplateName"":""Diploma"",
                ""Fields"":[],
                ""Signature"":null}";
            Template subject = JsonConvert.DeserializeObject<Template>(serialized);
            Assert.Equal("testFile.png", subject.ResourcePath);
            Assert.Equal("Diploma", subject.TemplateName);
            Assert.Null(subject.Signature);
            Assert.Empty(subject.Fields.ToArray());
        }

        [Fact]
        public void SerializesToJSON()
        {
            var subject = new Template("Serializes", "file.png", new Field[] { });

            string json = JsonConvert.SerializeObject(subject);

            Assert.Equal(@"{""TemplateName"":""Serializes"",""ResourcePath"":""file.png"",""Fields"":[],""Signature"":null}", json);
        }
    }
}
