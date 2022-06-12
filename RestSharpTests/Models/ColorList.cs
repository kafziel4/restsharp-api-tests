using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestSharpTests.Models
{
    internal class ColorList : ListProperties
    {
        [JsonProperty("data")]
        public List<ColorData> Data { get; set; }
    }
}
