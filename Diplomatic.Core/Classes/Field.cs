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
        [JsonProperty]
        private readonly double XOffset;
        [JsonProperty]
        private readonly double YOffset;
        [JsonProperty]
        private readonly double Height;
        [JsonProperty]
        private readonly double Width;

        public Field(string name, double x, double y, double h, double w)
        {
            Name = name;
            Value = "";
            XOffset = x;
            YOffset = y;
            Height = h;
            Width = w;
        }

        public void Deconstruct(out double x, out double y, out double h, out double w)
        {
            x = XOffset;
            y = YOffset;
            h = Height;
            w = Width;
        }
    }
}
