using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Login;

public record LoginRequest(
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("password")] string? Password = null
);

