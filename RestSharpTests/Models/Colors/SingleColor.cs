using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Colors;

public class SingleColor
{
    [JsonPropertyName("data")]
    public ColorData Data { get; set; }
}
