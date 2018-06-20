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
        private readonly int XOffset;
        [JsonProperty]
        private readonly int YOffset;
        [JsonProperty]
        private readonly int Height;
        [JsonProperty]
        private readonly int Width;

        public Field(string name, int x, int y, int w, int h)
        {
            Name = name;
            Value = "";
            XOffset = x;
            YOffset = y;
            Height = h;
            Width = w;
        }

        public void Deconstruct(out int x, out int y, out int w, out int h)
        {
            x = XOffset;
            y = YOffset;
            h = Height;
            w = Width;
        }
    }
}
