using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
        var faker = new Faker("pt_BR");
        var icContaCredito = false;
        var icContaDebito = false;
        var codigoProduto = 110;
        var codigoModalidade = 0;
        var operacaoConta = faker.Random.Int(100, 999);
        var codigoConvenio = 1;

        await _fixture.LoginApi();

        // Act
        var response = await _fixture.Client.GetAsync("");

        // Assert
       Assert.True(true);
    }
}