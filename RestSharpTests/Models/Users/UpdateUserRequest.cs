using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public record UpdateUserRequest(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("job")] string Job
);
