using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Net;

namespace AlbertoSouza.BackendChallengeApplication.Api.IntegrationTest;


public class JwtValidatorControllerIntegrationTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory = factory;

    private readonly Dictionary<int, string> _mappedCases = new()
    {
        { 1, "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MSIsIk5hbWUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05sIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg" },
        { 2, "eyJhbGciOiJzI1NiJ9.dfsdfsfryJSr2xrIjoiQWRtaW4iLCJTZrkIjoiNzg0MSIsIk5hbrUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05fsdfsIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg" },
        { 3, "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiRXh0ZXJuYWwiLCJTZWVkIjoiODgwMzciLCJOYW1lIjoiTTRyaWEgT2xpdmlhIn0.6YD73XWZYQSSMDf6H0i3-kylz1-TY_Yt6h1cV2Ku-Qs" } ,
        { 4, "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiTWVtYmVyIiwiT3JnIjoiQlIiLCJTZWVkIjoiMTQ2MjciLCJOYW1lIjoiVmFsZGlyIEFyYW5oYSJ9.cmrXV_Flm5mfdpfNUVopY_I2zeJUy4EZ4i3Fea98zvY" }
    };

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, false)]
    [InlineData(3, false)]
    [InlineData(4, false)]
    public async Task GiveOneJwtData_WhenCalledApiJwtValidator_ThenReturnsOKStatusCodeAndExpectedIsValid(int caseId, bool expectedIsValid)
    {
        // Arrange / Give
        var client = _factory.CreateClient();
        var jwtItem = _mappedCases[caseId];

        // Act / When
        var response = await client.GetAsync($"api/jwtvalidator?jwt={jwtItem}");
        var content = await response.Content.ReadFromJsonAsync<bool>();

        // Assert / Then
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expectedIsValid, content);
    }
}
