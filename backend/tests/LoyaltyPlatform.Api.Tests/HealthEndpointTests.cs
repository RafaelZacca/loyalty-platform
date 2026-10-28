using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LoyaltyPlatform.Api.Tests;

public class HealthEndpointTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    // Points at a closed port so readiness fails fast without a running database.
    private const string UnreachableDb =
        "Host=127.0.0.1;Port=1;Database=x;Username=x;Password=x;Timeout=2;Command Timeout=2";

    private HttpClient CreateClient() => factory
        .WithWebHostBuilder(b => b.UseSetting("ConnectionStrings:Default", UnreachableDb))
        .CreateClient();

    [Fact]
    public async Task Live_ReturnsOk_WithoutDatabase()
    {
        var response = await CreateClient().GetAsync("/health/live");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Ready_ReturnsServiceUnavailable_WhenDatabaseUnreachable()
    {
        var response = await CreateClient().GetAsync("/health/ready");

        Assert.Equal(HttpStatusCode.ServiceUnavailable, response.StatusCode);
    }
}
