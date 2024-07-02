using System.Net.Http.Headers;
using System.Net.Http.Json;
using Lab.Commons.IntegrationTest.Factory;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Lab.Commons.IntegrationTest.Fixtures;

[CollectionDefinition(nameof(IntegrationTestFixtureCollection<TProgram>))]
public class IntegrationTestFixtureCollection<TProgram> : ICollectionFixture<IntegrationTestFixture<TProgram>>
    where TProgram : class
{
}

public class IntegrationTestFixture<TProgram> : IAsyncLifetime where TProgram : class
{
    public readonly AppFactory<TProgram> AppFactory;
    public readonly HttpClient Client;
    public readonly IServiceScope ServiceScope;
    public UserTest? User;

    public IntegrationTestFixture()
    {
        AppFactory = new AppFactory<TProgram>();
        ServiceScope = AppFactory.Services.CreateScope();

        Client = AppFactory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true,
            HandleCookies = true,
            MaxAutomaticRedirections = 7
        });
    }

    public async Task DisposeAsync()
    {
        ServiceScope?.Dispose();
        Client?.Dispose();
    }

    public async Task InitializeAsync()
    {
    }

    public async Task<UserTest> LoginApi(UserLogin userLogin, bool setDefault = true)
    {
        using var client = new HttpClient();

        var request = new HttpRequestMessage(HttpMethod.Post, "");

        var formCollection = new List<KeyValuePair<string, string>>
        {
            new("grant_type", userLogin.GrantType),
            new("client_id", userLogin.ClientId),
            new("username", userLogin.UserName),
            new("password", userLogin.Password)
        };

        request.Content = new FormUrlEncodedContent(formCollection);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseToken = await response.Content.ReadFromJsonAsync<UserTest>();

        if (responseToken is null) throw new Exception("Login inválido");

        if (setDefault) SetDefaultUser(responseToken);

        return responseToken;
    }

    public void SetDefaultUser(UserTest user)
    {
        User = user;
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.AccessToken);
    }
}