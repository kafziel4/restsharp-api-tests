using FluentAssertions;
using RestSharp;
using RestSharpTests.Clients;
using RestSharpTests.Data;
using RestSharpTests.Fixtures;
using RestSharpTests.Models.Colors;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RestSharpTests;

[Collection(Constants.ReqResCollection)]
public class ColorsTests
{
    private readonly ReqResClient _reqResClient;

    public ColorsTests(ReqResFixture fixture)
    {
        _reqResClient = fixture.ReqResClient;
    }

    [Fact]
    public async Task GetColors_ShouldReturnStatusOK_AndColorsList()
    {
        // Arrange
        var expectedResponse = Colors.ColorList;

        // Act
        var response = await _reqResClient.GetColorsAsync();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task GetColorForExistingColor_ShouldReturnStatusOK_AndColorData()
    {
        // Arrange
        var expectedResponse = new SingleColor(
            Data: new ColorData(
                Id: 2, 
                Name: "fuchsia rose", 
                Year: 2001,
                Color: "#C74375", 
                PantoneValue: "17-2031"
            )
        );

        // Act
        var response = await _reqResClient.GetSingleColorAsync(expectedResponse.Data.Id);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task GetColorForColorThatDoesNotExist_ShouldReturnStatusNotFound()
    {
        // Arrange
        var nonexistentId = 23;

        // Act
        var response = await _reqResClient.GetSingleColorAsync(nonexistentId);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        response.ContentType.Should().Be(ContentType.Json);
        response.Data.Data.Should().BeNull();
    }
}