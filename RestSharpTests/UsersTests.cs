using FluentAssertions;
using FluentAssertions.Extensions;
using RestSharp;
using RestSharpTests.Clients;
using RestSharpTests.Data;
using RestSharpTests.Fixtures;
using RestSharpTests.Models.Users;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace RestSharpTests;

[Collection(Constants.ReqResCollection)]
public class UsersTests
{
    private readonly ReqResClient _reqResClient;

    public UsersTests(ReqResFixture fixture)
    {
        _reqResClient = fixture.ReqResClient;
    }

    [Fact]
    public async Task GetUsers_ShouldReturnStatusOK_AndUsersList()
    {
        // Arrange
        var page = 2;
        var expectedResponse = Users.UserList;

        // Act
        var response = await _reqResClient.GetUsersAsync(page);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task GetUserForExistingUser_ShouldReturnStatusOK_AndUserData()
    {
        // Arrange
        var expectedUResponse = new SingleUser
        {
            Data = new UserData
            {
                Id = 2,
                Email = "janet.weaver@reqres.in",
                FirstName = "Janet",
                LastName = "Weaver",
                Avatar = "https://reqres.in/img/faces/2-image.jpg"
            }
        };

        // Act
        var response = await _reqResClient.GetSingleUserAsync(expectedUResponse.Data.Id);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(expectedUResponse);
    }

    [Fact]
    public async Task GetUserForUserThatDoesNotExist_ShouldReturnStatusNotFound()
    {
        // Arrange
        var nonexistentId = 23;

        // Act
        var response = await _reqResClient.GetSingleUserAsync(nonexistentId);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Data.Should().BeNull();
    }

    [Fact]
    public async Task PostUserWithValidData_ShouldReturnStatusCreated_AndUserData()
    {
        // Arrange
        var requestBody = new CreateUserRequest
        {
            Name = "morpheus",
            Job = "leader"
        };

        var oneToThreeDigits = new Regex(@"^\d{1,3}$");

        // Act
        var response = await _reqResClient.PostUserAsync(requestBody);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(requestBody, options =>
            options.ExcludingMissingMembers());
        response.Data.Id.Should().MatchRegex(oneToThreeDigits);
        response.Data.CreatedAt.Should().BeWithin(1.Seconds()).Before(DateTimeOffset.Now);
    }

    [Fact]
    public async Task PutUserForExistingUserWithValidData_ShouldReturnStatusOK_AndUserData()
    {
        // Arrange
        var id = 2;
        var requestBody = new UpdateUserRequest
        {
            Name = "morpheus",
            Job = "zion resident"
        };

        // Act
        var response = await _reqResClient.PutUserAsync(id, requestBody);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(requestBody, options =>
            options.ExcludingMissingMembers());
        response.Data.UpdatedAt.Should().BeWithin(1.Seconds()).Before(DateTimeOffset.Now);
    }

    [Fact]
    public async Task PatchUserForExistingUserWithValidData_ShouldReturnStatusOK_AndUserData()
    {
        // Arrange
        var id = 2;
        var requestBody = new UpdateUserRequest
        {
            Name = "morpheus",
            Job = "zion resident"
        };

        // Act
        var response = await _reqResClient.PatchUserAsync(id, requestBody);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(requestBody, options =>
            options.ExcludingMissingMembers());
        response.Data.UpdatedAt.Should().BeWithin(1.Seconds()).Before(DateTimeOffset.Now);
    }

    [Fact]
    public async Task DeleteUserForExistingUser_ShouldReturnStatusNoContent()
    {
        // Arrange
        var id = 2;

        // Act
        var response = await _reqResClient.DeleteUserAsync(id);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        response.ContentLength.Should().Be(0);
    }
}
