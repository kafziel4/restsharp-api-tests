using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public class UpdateUserRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("job")]
    public string Job { get; set; }
}
