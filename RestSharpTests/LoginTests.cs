using FluentAssertions;
using RestSharp;
using RestSharpTests.Clients;
using RestSharpTests.Fixtures;
using RestSharpTests.Models;
using RestSharpTests.Models.Login;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestSharpTests;

[Collection(Constants.ReqResCollection)]
public class LoginTests
{
    private readonly ReqResClient _reqResClient;

    public LoginTests(ReqResFixture fixture)
    {
        _reqResClient = fixture.ReqResClient;
    }

    [Fact]
    public async Task PostLoginWithValidData_ShouldReturnStatusOK_AndLoginToken()
    {
        // Arrange
        var requestBody = new LoginRequest(Email: "eve.holt@reqres.in", Password: "pistol");
        var expectedResponse = new LoginResponse(Token: "QpwL5tke4Pnpja7X4");

        // Act
        var response = await _reqResClient.PostLoginAsync<LoginResponse>(requestBody);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task PostLoginWithMissingPassword_ShouldReturnStatusBadRequest_AndValidationError()
    {
        // Arrange
        var requestBody = new LoginRequest(Email: "peter@klaven");
        var expectedResponse = new ErrorResponse(Error: "Missing password");

        // Act
        var response = await _reqResClient.PostLoginAsync<ErrorResponse>(requestBody);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(expectedResponse);
    }
}