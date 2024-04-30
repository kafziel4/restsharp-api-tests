using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Login;

public record LoginResponse([property: JsonPropertyName("token")] string Token);