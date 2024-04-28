using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Register;

public class RegisterRequest
{
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
}
