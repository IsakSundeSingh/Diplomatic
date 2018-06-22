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
            subject = new Field("Test field", 1, 2, 3, 4);
            serialized = @"{
                ""Name"":""Test field"",
                ""XOffset"":1,
                ""YOffset"":2,
                ""Height"":3,
                ""Width"":4
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

        [Fact]
        public void DestructuresWithTupleAssignment()
        {
            (var x, var y, var w, var h) = subject;
            Assert.Equal(1, x);
            Assert.Equal(2, y);
            Assert.Equal(3, w);
            Assert.Equal(4, h);
        }
    }
}
