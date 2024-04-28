using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Login;

public class LoginResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
}
