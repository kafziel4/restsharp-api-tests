using System.Text.Json.Serialization;

namespace RestSharpTests.Models;

public class Pagination
{
    [JsonPropertyName("page")]
    public int Page { get; set; }
    
    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }
    
    [JsonPropertyName("total")]
    public int Total { get; set; }
    
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
}
