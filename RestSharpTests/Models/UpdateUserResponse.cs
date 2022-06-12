using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class UpdateUserResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}
