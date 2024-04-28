using System.Text.Json.Serialization;

namespace RestSharpTests.Models;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; }
}
