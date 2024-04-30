using System;
using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public record UpdateUserResponse(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("job")] string Job,
    [property: JsonPropertyName("updatedAt")] DateTimeOffset UpdatedAt
);
