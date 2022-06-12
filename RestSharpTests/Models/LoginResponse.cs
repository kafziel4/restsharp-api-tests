using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
