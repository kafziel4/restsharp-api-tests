using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Register;

public record RegisterRequest(
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("password")] string? Password = null
);
