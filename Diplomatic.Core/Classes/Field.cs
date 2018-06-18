using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomatic.Core
{
    [Serializable]
    public class Field
    {
        public string Name;
        [JsonIgnore]
        public string Value { get; set; }
        [JsonIgnore]
        public bool IsValid => !String.IsNullOrWhiteSpace(Value);
        [JsonProperty]
        private readonly int XOffset;
        [JsonProperty]
        private readonly int YOffset;
        [JsonProperty]
        private readonly int Height;
        [JsonProperty]
        private readonly int Width;

        public Field(string name, int x, int y, int h, int w)
        {
            Name = name;
            Value = "";
            XOffset = x;
            YOffset = y;
            Height = h;
            Width = w;
        }
    }
}
