using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public record SingleUser([property: JsonPropertyName("data")] UserData Data);
