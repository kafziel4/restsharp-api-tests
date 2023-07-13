using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharpTests.Data;
using RestSharpTests.Models;
using Xunit;

namespace RestSharpTests
{
    public class ApiTest
    {
        private readonly RestClient _client;
        private readonly Regex _oneToThreeDigits = new(@"^\d{1,3}$");
        private readonly Regex _dateInISOFormat = new(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}.\d{3}Z$");

        public ApiTest()
        {
            _client = new RestClient("https://reqres.in/api");
            _client.UseNewtonsoftJson();
        }

        [Fact]
        public async Task GetUsers_ShouldReturnStatusOK_AndUsersList()
        {
            // Act
            var request = new RestRequest("/users")
                .AddParameter("page", "2");
            var response = await _client.ExecuteAsync<UserList>(request, Method.Get);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.ContentType.Should().Be("application/json");

            var responseBody = response.Data;
            responseBody.Page.Should().Be(2);
            responseBody.PerPage.Should().Be(6);
            responseBody.Total.Should().Be(12);
            responseBody.TotalPages.Should().Be(2);
            responseBody.Data.Should().HaveCount(6);

            var users = Users.GetUsers();
            for (int i = 0; i < users.Count; i++)
            {
                var responseUsersData = responseBody.Data;
                responseUsersData[i].Id.Should().Be(users[i].Id);
                responseUsersData[i].Email.Should().Be(users[i].Email);
                responseUsersData[i].FirstName.Should().Be(users[i].FirstName);
                responseUsersData[i].LastName.Should().Be(users[i].LastName);
                responseUsersData[i].Avatar.Should().Be(users[i].Avatar);
            }
        }

        [Fact]
        public async Task GetUserForExistingUser_ShouldReturnStatusOK_AndUserData()
        {
            // Act
            var request = new RestRequest("/users/{id}")
                .AddUrlSegment("id", "2");
            var response = await _client.ExecuteAsync<SingleUser>(request, Method.Get);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.ContentType.Should().Be("application/json");

            var responseUserData = response.Data.Data;
            responseUserData.Id.Should().Be(2);
            responseUserData.Email.Should().Be("janet.weaver@reqres.in");
            responseUserData.FirstName.Should().Be("Janet");
            responseUserData.LastName.Should().Be("Weaver");
            responseUserData.Avatar.Should().Be("https://reqres.in/img/faces/2-image.jpg");
        }

        [Fact]
        public async Task GetUserForUserThatDoesNotExist_ShouldReturnStatusNotFound()
        {
            // Act
            var request = new RestRequest("/users/{id}")
                .AddUrlSegment("id", "23");
            var response = await _client.ExecuteAsync(request, Method.Get);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            response.ContentType.Should().Be("application/json");

            response.Content.Should().Be("{}");
        }

        [Fact]
        public async Task GetColors_ShouldReturnStatusOK_AndColorsList()
        {
            // Act
            var request = new RestRequest("/colors");
            var response = await _client.ExecuteAsync<ColorList>(request, Method.Get);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.ContentType.Should().Be("application/json");

            var responseBody = response.Data;
            responseBody.Page.Should().Be(1);
            responseBody.PerPage.Should().Be(6);
            responseBody.Total.Should().Be(12);
            responseBody.TotalPages.Should().Be(2);
            responseBody.Data.Should().HaveCount(6);

            var colors = Colors.GetColors();
            for (int i = 0; i < colors.Count; i++)
            {
                var responseUsersData = responseBody.Data;
                responseUsersData[i].Id.Should().Be(colors[i].Id);
                responseUsersData[i].Name.Should().Be(colors[i].Name);
                responseUsersData[i].Year.Should().Be(colors[i].Year);
                responseUsersData[i].Color.Should().Be(colors[i].Color);
                responseUsersData[i].PantoneValue.Should().Be(colors[i].PantoneValue);
            }
        }

        [Fact]
        public async Task GetColorForExistingColor_ShouldReturnStatusOK_AndColorData()
        {
            // Act
            var request = new RestRequest("/colors/{id}")
                .AddUrlSegment("id", "2");
            var response = await _client.ExecuteAsync<SingleColor>(request, Method.Get);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.ContentType.Should().Be("application/json");

            var responseUserData = response.Data.Data;
            responseUserData.Id.Should().Be(2);
            responseUserData.Name.Should().Be("fuchsia rose");
            responseUserData.Year.Should().Be(2001);
            responseUserData.Color.Should().Be("#C74375");
            responseUserData.PantoneValue.Should().Be("17-2031");
        }

        [Fact]
        public async Task GetColorForColorThatDoesNotExist_ShouldReturnStatusNotFound()
        {
            // Act
            var request = new RestRequest("/colors/{id}")
                .AddUrlSegment("id", "23");
            var response = await _client.ExecuteAsync(request, Method.Get);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            response.ContentType.Should().Be("application/json");

            response.Content.Should().Be("{}");
        }

        [Fact]
        public async Task PostUserWithValidData_ShouldReturnStatusCreated_AndUserData()
        {
            // Arrange
            var requestBody = new CreateOrUpdateUserRequest() { Name = "morpheus", Job = "leader" };
            
            // Act
            var request = new RestRequest("/users")
                .AddJsonBody(requestBody);
            var response = await _client.ExecuteAsync<CreateUserResponse>(request, Method.Post);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            response.ContentType.Should().Be("application/json");

            var responseUserData = response.Data;
            responseUserData.Name.Should().Be(requestBody.Name);
            responseUserData.Job.Should().Be(requestBody.Job);
            responseUserData.Id.Should().MatchRegex(_oneToThreeDigits);
            responseUserData.CreatedAt.Should().MatchRegex(_dateInISOFormat);
        }

        [Fact]
        public async Task PutUserForExistingUserWithValidData_ShouldReturnStatusOK_AndUserData()
        {
            // Arrange
            var requestBody = new CreateOrUpdateUserRequest() { Name = "morpheus", Job = "zion resident" };

            // Act
            var request = new RestRequest("/users/{id}")
                .AddUrlSegment("id", "2")
                .AddJsonBody(requestBody);
            var response = await _client.ExecuteAsync<UpdateUserResponse>(request, Method.Put);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.ContentType.Should().Be("application/json");

            var responseUserData = response.Data;
            responseUserData.Name.Should().Be(requestBody.Name);
            responseUserData.Job.Should().Be(requestBody.Job);
            responseUserData.UpdatedAt.Should().MatchRegex(_dateInISOFormat);
        }

        [Fact]
        public async Task PatchUserForExistingUserWithValidData_ShouldReturnStatusOK_AndUserData()
        {
            // Arrange
            var requestBody = new CreateOrUpdateUserRequest() { Name = "morpheus", Job = "zion resident" };

            // Act
            var request = new RestRequest("/users/{id}")
                .AddUrlSegment("id", "2")
                .AddJsonBody(requestBody);
            var response = await _client.ExecuteAsync<UpdateUserResponse>(request, Method.Patch);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.ContentType.Should().Be("application/json");

            var responseUserData = response.Data;
            responseUserData.Name.Should().Be(requestBody.Name);
            responseUserData.Job.Should().Be(requestBody.Job);
            responseUserData.UpdatedAt.Should().MatchRegex(_dateInISOFormat);
        }

        [Fact]
        public async Task DeleteUserForExistingUser_ShouldReturnStatusNoContent()
        {
            // Act
            var request = new RestRequest("/users/{id}")
                .AddUrlSegment("id", "2");
            var response = await _client.ExecuteAsync(request, Method.Delete);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            response.ContentLength.Should().Be(0);
        }

        [Fact]
        public async Task PostRegisterWithValidData_ShouldReturnStatusOK_AndRegistrationId_AndToken()
        {
            // Arrange
            var requestBody = new RegisterOrLoginRequest() { Email = "eve.holt@reqres.in", Password = "pistol" };

            // Act
            var request = new RestRequest("/register")
                .AddJsonBody(requestBody);
            var response = await _client.ExecuteAsync<RegisterResponse>(request, Method.Post);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.ContentType.Should().Be("application/json");

            var responseUserData = response.Data;
            responseUserData.Id.Should().Be(4);
            responseUserData.Token.Should().Be("QpwL5tke4Pnpja7X4");
        }

        [Fact]
        public async Task PostRegisterWithMissingPassword_ShouldReturnStatusBadRequest_AndValidationError()
        {
            // Arrange
            var requestBody = new RegisterOrLoginRequest() { Email = "sydney@fife" };

            // Act
            var request = new RestRequest("/register")
                .AddJsonBody(requestBody);
            var response = await _client.ExecuteAsync<ErrorResponse>(request, Method.Post);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            response.ContentType.Should().Be("application/json");

            response.Data.Error.Should().Be("Missing password");
        }

        [Fact]
        public async Task PostLoginWithValidData_ShouldReturnStatusOK_AndLoginToken()
        {
            // Arrange
            var requestBody = new RegisterOrLoginRequest() { Email = "eve.holt@reqres.in", Password = "pistol" };

            // Act
            var request = new RestRequest("/login")
                .AddJsonBody(requestBody);
            var response = await _client.ExecuteAsync<RegisterResponse>(request, Method.Post);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.ContentType.Should().Be("application/json");

            response.Data.Token.Should().Be("QpwL5tke4Pnpja7X4");
        }

        [Fact]
        public async Task PostLoginWithMissingPassword_ShouldReturnStatusBadRequest_AndValidationError()
        {
            // Arrange
            var requestBody = new RegisterOrLoginRequest() { Email = "peter@klaven" };

            // Act
            var request = new RestRequest("/login")
                .AddJsonBody(requestBody);
            var response = await _client.ExecuteAsync<ErrorResponse>(request, Method.Post);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            response.ContentType.Should().Be("application/json");

            response.Data.Error.Should().Be("Missing password");
        }
    }
}
