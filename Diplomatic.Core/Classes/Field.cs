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
        private readonly double xOffset;
        [JsonProperty("YOffset")]
        private readonly double yOffset;
        [JsonProperty("Width")]
        private readonly double width;
        [JsonProperty("Height")]
        private readonly double height;
        [JsonProperty("Color")]
        private readonly string color;


        public Field(string name, string col, double x, double y, double w, double h)
        {
            Name = name;
            Value = "";
            color = col;
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
