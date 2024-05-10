using System.Net;
using System.Net.Http.Json;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.IntegrationTest;
[TestClass]
public class GetTypeTestClass
{
    private static readonly HttpClient HttpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5022") };
    
    [TestMethod]
    public async Task GetPokemonType_ReturnsOkStatus()
    {
        // Arrange
        var typeName = "tackle";

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/ByType/{typeName}");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    public async Task GetPokemonType_ReturnsPokemonType()
    {
        // Arrange
        var typeName = "tackle";

        // Act
        var pokemonType = await HttpClient.GetFromJsonAsync<Moves>($"/api/Pokemon/ByType/{typeName}");

        // Assert
        Assert.IsNotNull(pokemonType);
        Assert.AreEqual(typeName, pokemonType.Name);
    }

    [TestMethod]
    public async Task GetPokemonType_EmptyTypeName_ReturnsNotFound()
    {
        // Arrange
        var emptyTypeName = "";

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/ByType/{emptyTypeName}");

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    public async Task GetType_FromAPI()
    {
        // Arrange 
        string type = "mega-punch";
        
        // Act
        var pokemonType = await HttpClient.GetFromJsonAsync<Moves>($"/api/Pokemon/ByType/{type}");

        var apiPokemon = await HttpClient.GetFromJsonAsync<Moves>($"https://pokeapi.co/api/v2/move/{type}");
        // Assert
        Assert.AreEqual(pokemonType!.Name, apiPokemon!.Name);
    }
}