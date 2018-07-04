using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace Diplomatic.Tests
{
    using Models;
    public class TemplateTest
    {
        private readonly Field[] validFields;
        private readonly Field[] invalidFields;
        private Template subject;

        public TemplateTest()
        {
            var validField = new Field("Valid");
            validField.Value = "non-empty";
            validFields = new Field[] { validField };

            var invalidField = new Field("Invalid");
            invalidFields = new Field[] { invalidField };
        }

        [Fact]
        public void ValidatesFieldsAreFilled()
        {
            subject = new Template(true, invalidFields);
            Assert.False(subject.IsValid);

            subject = new Template(true, validFields);
            Assert.True(subject.IsValid);
        }

        [Fact]
        public void DeserializesFromJSON()
        {
            string serialized = @"{""signature"": true, ""fields"":[]}";

            subject = JsonConvert.DeserializeObject<Template>(serialized);

            Assert.Empty(subject.Fields.ToArray());
        }

        [Fact]
        public void SerializesToJSON()
        {
            var subject = new Template(true, new Field[] { });

            string json = JsonConvert.SerializeObject(subject);

            Assert.Equal(@"{""fields"":[],""signature"":true}", json);
        }
    }
}
