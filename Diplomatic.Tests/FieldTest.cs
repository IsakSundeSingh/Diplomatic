using Diplomatic.Core;
using Newtonsoft.Json;
using Xunit;

namespace Diplomatic.Tests
{
    public class FieldTest
    {
        readonly Field subject;
        readonly string serialized;

        public FieldTest()
        {
            subject = new Field("Test field", 10, 10, 20, 100);
            serialized = @"{
                ""Name"":""Test field"",
                ""XOffset"":10,
                ""YOffset"":10,
                ""Height"":20,
                ""Width"":100
            }";
        }

        [Fact]
        public void FieldSerializesToJSON()
        {
            var output = JsonConvert.SerializeObject(subject);
            Assert.Contains("Name", output);
            Assert.Contains("XOffset", output);
            Assert.Contains("YOffset", output);
            Assert.Contains("Width", output);
            Assert.Contains("Height", output);
        }

        [Fact]
        public void FieldDeserializesFromJSON()
        {
            var field = JsonConvert.DeserializeObject<Field>(serialized);
            Assert.Equal("Test field", field.Name);
        }

        [Fact]
        public void EmptyFieldIsNotValid()
        {
            Assert.Equal("", subject.Value);
            Assert.False(subject.IsValid);
        }

        [Fact]
        public void FilledFieldIsValid()
        {
            subject.Value = "test";
            Assert.True(subject.IsValid);
        }
    }
}
