using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Users;

public record UserList(
    int Page,
    int PerPage,
    int Total,
    int TotalPages,
    [property: JsonPropertyName("data")] List<UserData> Data
) : Pagination (Page, PerPage, Total, TotalPages);
