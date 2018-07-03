using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace Diplomatic.Utils
{
    public class WebTemplateProvider
    {
        private readonly List<Template> templates;
        public IEnumerable<Template> GetTemplates() => templates.Select(t => t);

        public WebTemplateProvider()
        {
            var request = WebRequest.Create(new Uri("https://qri7p78aml.execute-api.eu-west-2.amazonaws.com/dev/templates.json"));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (var response = request.GetResponse() as HttpWebResponse)
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string content = reader.ReadToEnd();
                templates = JsonConvert.DeserializeObject<List<Template>>(content);
            }
        }
    }
}
