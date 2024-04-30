using FluentAssertions;
using RestSharp;
using RestSharpTests.Clients;
using RestSharpTests.Fixtures;
using RestSharpTests.Models;
using RestSharpTests.Models.Register;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestSharpTests;

[Collection(Constants.ReqResCollection)]
public class RegisterTests
{
    private readonly ReqResClient _reqResClient;

    public RegisterTests(ReqResFixture fixture)
    {
        _reqResClient = fixture.ReqResClient;
    }

    [Fact]
    public async Task PostRegisterWithValidData_ShouldReturnStatusOK_AndRegistrationId_AndToken()
    {
        // Arrange
        var requestBody = new RegisterRequest(Email: "eve.holt@reqres.in", Password: "pistol");
        var expectedResponse = new RegisterResponse(Id: 4, Token: "QpwL5tke4Pnpja7X4");

        // Act
        var response = await _reqResClient.PostRegisterAsync<RegisterResponse>(requestBody);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task PostRegisterWithMissingPassword_ShouldReturnStatusBadRequest_AndValidationError()
    {
        // Arrange
        var requestBody = new RegisterRequest(Email: "sydney@fife");
        var expectedResponse = new ErrorResponse(Error: "Missing password");

        // Act
        var response = await _reqResClient.PostRegisterAsync<ErrorResponse>(requestBody);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(expectedResponse);
    }
}