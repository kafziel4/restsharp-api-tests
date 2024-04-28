using RestSharp;
using RestSharpTests.Models.Colors;
using RestSharpTests.Models.Login;
using RestSharpTests.Models.Register;
using RestSharpTests.Models.Users;
using System.Threading.Tasks;

namespace RestSharpTests.Clients;

public class ReqResClient
{
    private const string UsersPath = "/users";
    private const string ColorsPath = "/colors";
    private const string RegisterPath = "/register";
    private const string LoginPath = "/login";
    private readonly RestClient _client;

    public ReqResClient()
    {
        _client = new RestClient("https://reqres.in/api");
    }

    public async Task<RestResponse<UserList>> GetUsersAsync(int page)
    {
        var request = new RestRequest(UsersPath)
            .AddParameter("page", page);
        return await _client.ExecuteAsync<UserList>(request, Method.Get);
    }

    public async Task<RestResponse<SingleUser>> GetSingleUserAsync(int id)
    {
        var request = new RestRequest($"{UsersPath}/{{id}}")
            .AddUrlSegment("id", id);
        return await _client.ExecuteAsync<SingleUser>(request, Method.Get);
    }

    public async Task<RestResponse<CreateUserResponse>> PostUserAsync(CreateUserRequest body)
    {
        var request = new RestRequest(UsersPath)
            .AddJsonBody(body);
        return await _client.ExecuteAsync<CreateUserResponse>(request, Method.Post);
    }

    public async Task<RestResponse<UpdateUserResponse>> PutUserAsync(int id, UpdateUserRequest body)
    {
        var request = new RestRequest($"{UsersPath}/{{id}}")
            .AddUrlSegment("id", id)
            .AddJsonBody(body);
        return await _client.ExecuteAsync<UpdateUserResponse>(request, Method.Put);
    }

    public async Task<RestResponse<UpdateUserResponse>> PatchUserAsync(int id, UpdateUserRequest body)
    {
        var request = new RestRequest($"{UsersPath}/{{id}}")
            .AddUrlSegment("id", id)
            .AddJsonBody(body);
        return await _client.ExecuteAsync<UpdateUserResponse>(request, Method.Patch);
    }

    public async Task<RestResponse> DeleteUserAsync(int id)
    {
        var request = new RestRequest($"{UsersPath}/{{id}}")
            .AddUrlSegment("id", id);
        return await _client.ExecuteAsync(request, Method.Delete);
    }

    public async Task<RestResponse<ColorList>> GetColorsAsync()
    {
        var request = new RestRequest(ColorsPath);
        return await _client.ExecuteAsync<ColorList>(request, Method.Get);
    }

    public async Task<RestResponse<SingleColor>> GetSingleColorAsync(int id)
    {
        var request = new RestRequest($"{ColorsPath}/{{id}}")
            .AddUrlSegment("id", id);
        return await _client.ExecuteAsync<SingleColor>(request, Method.Get);
    }

    public async Task<RestResponse<T>> PostRegisterAsync<T>(RegisterRequest body)
    {
        var request = new RestRequest(RegisterPath)
            .AddJsonBody(body);
        return await _client.ExecuteAsync<T>(request, Method.Post);
    }

    public async Task<RestResponse<T>> PostLoginAsync<T>(LoginRequest body)
    {
        var request = new RestRequest(LoginPath)
            .AddJsonBody(body);
        return await _client.ExecuteAsync<T>(request, Method.Post);
    }
}
