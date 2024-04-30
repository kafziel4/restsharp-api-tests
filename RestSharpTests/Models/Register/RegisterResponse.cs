using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Register;

public record RegisterResponse(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("token")] string Token
);
