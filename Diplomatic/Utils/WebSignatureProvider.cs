using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace Diplomatic.Utils
{
    using Models;

    public class WebSignatureProvider
    {
        private readonly IEnumerable<Signature> signatures;
        public IEnumerable<Signature> GetTemplates() => signatures.Select(obj => obj);

        public WebSignatureProvider()
        {
            var request = WebRequest.Create(new Uri("https://qri7p78aml.execute-api.eu-west-2.amazonaws.com/dev/signatures.json"));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (var response = request.GetResponse() as HttpWebResponse)
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string content = reader.ReadToEnd();
                signatures = JsonConvert.DeserializeObject<List<Signature>>(content);
            }
        }
    }
}
