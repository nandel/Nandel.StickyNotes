using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Entities
{
    public class HttpGet : Media
    {
        public const string MediaType = "http-get";

        private static readonly HttpClient HttpClient = new HttpClient()
        {
            DefaultRequestHeaders =
            {
                UserAgent = { new ProductInfoHeaderValue("StikyNotesBot", "1.0") }
            }
        };
        
        public Uri Address { get; set; }
        public string FieldToDisplay { get; set; }
        
        public override async Task<string> GetContentAsync()
        {
            var response = await HttpClient.GetAsync(Address);
            var responseText = await response.Content.ReadAsStringAsync();
            var responseJson = JToken.Parse(responseText);

            if (FieldToDisplay is not null)
            {
                responseJson = responseJson.SelectToken(FieldToDisplay);
            }
            
            var responsePretty = responseJson.ToString(Formatting.Indented);
            return $"```json{Environment.NewLine}{responsePretty}{Environment.NewLine}```";
        }
    }
}