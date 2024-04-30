using System.Text.Json.Serialization;

namespace RestSharpTests.Models;

public record ErrorResponse([property: JsonPropertyName("error")] string Error);
