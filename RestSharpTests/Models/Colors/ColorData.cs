using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Colors;

public record ColorData(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("year")] int Year,
    [property: JsonPropertyName("color")] string Color,
    [property: JsonPropertyName("pantone_value")] string PantoneValue
);
