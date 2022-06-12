using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestSharpTests.Models
{
    internal class UserList : ListProperties
    {
        [JsonProperty("data")]
        public List<UserData> Data { get; set; }
    }
}
