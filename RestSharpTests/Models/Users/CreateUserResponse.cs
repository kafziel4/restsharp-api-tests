using System;
using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public class CreateUserResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("job")]
    public string Job { get; set; }
    
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }
}
