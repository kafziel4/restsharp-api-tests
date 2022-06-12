using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class CreateUserResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
    }
}
