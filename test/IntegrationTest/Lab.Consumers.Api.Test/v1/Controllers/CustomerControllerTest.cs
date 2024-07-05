using Lab.Commons.IntegrationTest.Fixtures;

namespace Lab.Consumers.Api.Test.v1.Controllers;

[Collection(nameof(IntegrationTestFixtureCollection<Program>))]
public class CustomerControllerTest
{
    private readonly IntegrationTestFixture<Program> _fixture;

    public CustomerControllerTest(IntegrationTestFixture<Program> fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    [Trait("Category", "Integration Test - CustomerController")]
    public async Task ListCustomers_()
    {
        // Arrange

        //await _fixture.LoginApi();

        // Act
        var response = await _fixture.Client.GetAsync("");

        // Assert
        Assert.True(true);
    }
}