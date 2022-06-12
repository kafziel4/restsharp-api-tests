using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class RegisterResponse : LoginResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
