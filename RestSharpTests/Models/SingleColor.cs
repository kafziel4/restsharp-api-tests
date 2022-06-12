using Newtonsoft.Json;

namespace RestSharpTests.Models
{
    internal class SingleColor
    {
        [JsonProperty("data")]
        public ColorData Data { get; set; }
    }
}
