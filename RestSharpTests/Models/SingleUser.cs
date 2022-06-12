using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class SingleUser
    {
        [JsonProperty("data")]
        public UserData Data { get; set; }
    }
}
