using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public class SingleUser
{
    [JsonPropertyName("data")]
    public UserData Data { get; set; }
}
