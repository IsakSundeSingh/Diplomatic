using Newtonsoft.Json;
using System;

namespace Diplomatic.Core
{
    [Serializable]
    public class Field : IField
    {
        public string Name { get; }
        [JsonIgnore]
        public string Value { get; set; }
        [JsonIgnore]
        public bool IsValid => !string.IsNullOrWhiteSpace(Value);
        [JsonProperty("XOffset")]
        readonly double xOffset;
        [JsonProperty("YOffset")]
        readonly double yOffset;
        [JsonProperty("Width")]
        readonly double width;
        [JsonProperty("Height")]
        readonly double height;

        public Field(string name, double x, double y, double w, double h)
        {
            Name = name;
            Value = "";
            xOffset = x;
            yOffset = y;
            width = w;
            height = h;
        }

        public void Deconstruct(out double x, out double y, out double w, out double h)
        {
            x = xOffset;
            y = yOffset;
            w = width;
            h = height;
        }
    }
}
