using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Colors;

public record ColorList(
    int Page,
    int PerPage,
    int Total,
    int TotalPages,
    [property: JsonPropertyName("data")] List<ColorData> Data
) : Pagination (Page, PerPage, Total, TotalPages);
