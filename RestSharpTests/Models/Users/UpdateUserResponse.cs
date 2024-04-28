using System;
using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public class UpdateUserResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("job")]
    public string Job { get; set; }
    
    [JsonPropertyName("updatedAt")]
    public DateTimeOffset UpdatedAt { get; set; }
}
