using System.Collections.Generic;
using Newtonsoft.Json;

namespace Diplomatic.Models
{
    public class Template
    {
        [JsonProperty("fields")]
        public IEnumerable<Field> Fields { get; }
        public Signature Signature { get; set; }
        public string Name { get; set; }
        public bool HasSignature { get; }

        public Template(bool signature, IEnumerable<Field> fields)
        {
            Fields = fields;
            HasSignature = signature;
        }
    }
}
