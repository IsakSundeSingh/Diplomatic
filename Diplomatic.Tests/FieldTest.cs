using System.Collections.Generic;
using Diplomatic.Core;
using Newtonsoft.Json;
using Xunit;

namespace Diplomatic.Tests
{
    public class FieldTest
    {
        readonly Field subject;

        public FieldTest()
        {
            subject = new Field("Test field", 10, 10, 20, 100);
        }

        [Fact]
        public void FieldSerializesToJSON()
        {
            var serialized = JsonConvert.SerializeObject(subject);
            Assert.Contains("XOffset", serialized);
        }

        [Fact]
        public void FieldDeserializesFromJSON()
        {
            var serialized = @"{
                ""Name"":""name"",
                ""XOffset"":10,
                ""YOffset"":10,
                ""Height"":20,
                ""Width"":300
            }";

            var tempo = JsonConvert.DeserializeObject<Field>(serialized);
            Assert.Equal("name", tempo.Name);
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
