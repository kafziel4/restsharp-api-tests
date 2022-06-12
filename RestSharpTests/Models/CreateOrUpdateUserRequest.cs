using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class CreateOrUpdateUserRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
    }
}
