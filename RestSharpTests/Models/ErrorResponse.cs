using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class ErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
