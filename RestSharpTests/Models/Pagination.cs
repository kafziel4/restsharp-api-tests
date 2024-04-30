using System.Text.Json.Serialization;

namespace RestSharpTests.Models;

public record Pagination(
    [property: JsonPropertyName("page")] int Page,
    [property: JsonPropertyName("per_page")] int PerPage,
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("total_pages")] int TotalPages
);
