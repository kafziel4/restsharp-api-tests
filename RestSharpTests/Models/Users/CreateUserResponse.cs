using System;
using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public record CreateUserResponse(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("job")] string Job,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("createdAt")] DateTimeOffset CreatedAt
);
