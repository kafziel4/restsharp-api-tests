using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class RegisterOrLoginRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
