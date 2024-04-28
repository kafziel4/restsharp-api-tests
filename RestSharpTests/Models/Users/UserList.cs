using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public class UserList : Pagination
{
    [JsonPropertyName("data")]
    public List<UserData> Data { get; set; }
}
