using Newtonsoft.Json;
using Xunit;

namespace Diplomatic.Tests
{
    using Models;
    public class FieldTest
    {
        private readonly Field subject;
        private readonly string serialized;

        public FieldTest()
        {
            subject = new Field("Test field");
            serialized = @"{""name"":""Test field""}";
        }

        [Fact]
        public void FieldSerializesToJSON()
        {
            string output = JsonConvert.SerializeObject(subject);
            Assert.Contains("name", output);
        }

        [Fact]
        public void FieldDeserializesFromJSON()
        {
            Field field = JsonConvert.DeserializeObject<Field>(serialized);
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
