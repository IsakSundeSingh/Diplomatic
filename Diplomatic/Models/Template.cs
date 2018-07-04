using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Diplomatic.Models
{
    public class Template
    {
        [JsonProperty("fields")]
        public IEnumerable<Field> Fields { get; }
        [JsonProperty("signature")]
        public bool HasSignature { get; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public Signature Signature { get; set; }
        [JsonIgnore]
        public bool IsValid => Fields.All(f => f.IsValid);

        public Template(bool signature, IEnumerable<Field> fields)
        {
            Fields = fields;
            HasSignature = signature;
        }
    }
}
