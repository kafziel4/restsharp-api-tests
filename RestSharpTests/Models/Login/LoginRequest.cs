﻿using System.Text.Json.Serialization;

namespace RestSharpTests.Models.Login;

public class LoginRequest
{
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
}
