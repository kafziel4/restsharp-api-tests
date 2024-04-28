using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Colors;

public class ColorList : Pagination
{
    [JsonPropertyName("data")]
    public List<ColorData> Data { get; set; }
}
