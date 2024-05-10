using System.Net;
using System.Net.Http.Json;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.IntegrationTest;

[TestClass]
public class GetPokemonByIdOrNameTestClass
{
    private static readonly HttpClient HttpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5022") }; 

    [TestMethod]
    public async Task GetPokemonById_ReturnsOkStatus()
    {
        // Arrange
        var id = 1;

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/ById/{id}");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    public async Task GetPokemonById_FromPokeAPI()
    {
        // Arrange
        int id = 1;
        
        // Act
        var myPokemon = await HttpClient.GetFromJsonAsync<Pokemon>($"/api/Pokemon/ById/{id}");
        
        var apiPokemon = await HttpClient.GetFromJsonAsync<Pokemon>($"https://pokeapi.co/api/v2/pokemon/{id}/");
        
        // Assert
        Assert.AreEqual(myPokemon!.Name!,apiPokemon!.Name! );
    }
    
    [TestMethod]
    public async Task GetPokemonByName_ReturnsOkStatus()
    {
        // Arrange
        var name = "Bulbasaur";

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/ByName/{name.ToLower()}");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
    
    [TestMethod]
    public async Task GetPokemonByName_FromPokeAPI()
    {
        // Arrange
        string name = "Pikachu";
        
        // Act
        var myPokemon = await HttpClient.GetFromJsonAsync<Pokemon>($"/api/Pokemon/ByName/{name.ToLower()}");
        
        var apiPokemon = await HttpClient.GetFromJsonAsync<Pokemon>($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}/");
        
        // Assert
        Assert.AreEqual(myPokemon!.Name!,apiPokemon!.Name! );
    }
    
    [TestMethod]
    public async Task GetPokemonFromTwoMethods()
    {
        // Arrange
        string name = "Pikachu";

        int id = 25;
        
        // Act
        var myPokemonByName = await HttpClient.GetFromJsonAsync<Pokemon>($"/api/Pokemon/ByName/{name.ToLower()}");
        
        var myPokemonById = await HttpClient.GetFromJsonAsync<Pokemon>($"/api/Pokemon/ById/{id}");
        
        // Assert
        Assert.AreEqual((myPokemonByName!.Breeding.Weight , myPokemonByName.Breeding.Height!),
            (myPokemonById!.Breeding.Weight!, myPokemonById.Breeding.Height!));
    }
    [TestMethod]
    public async Task GetPokemonById_InvalidId_ReturnsNoContent()
    {
        // Arrange
        var invalidId = -1;

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/ById/{invalidId}");

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [TestMethod]
    public async Task GetPokemonByName_InvalidName_ReturnsNoContent()
    {
        // Arrange
        var invalidName = "string.Empty";

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/ById/{invalidName}");

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }
}