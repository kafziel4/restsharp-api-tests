using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Colors;

public record SingleColor([property: JsonPropertyName("data")] ColorData Data);
