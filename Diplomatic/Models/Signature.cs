using System;
using Newtonsoft.Json;

namespace Diplomatic.Models
{
    [Serializable]
    public class Signature
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        public Uri ImageUri {
            get {
                string basePath = $"https://qri7p78aml.execute-api.eu-west-2.amazonaws.com/dev/preview/signature/{Id}";
                return new Uri(basePath + "?width=200&height=80");
            }
        }
    }
}
