using System;
using Newtonsoft.Json;

namespace Diplomatic.Models
{
    [Serializable]
    public class Field
    {
        [JsonProperty("name")]
        public string Name { get; }
        [JsonIgnore]
        public string Value { get; set; }
        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(Value);

        public Field(string name)
        {
            Name = name;
            Value = "";
        }
    }
}
