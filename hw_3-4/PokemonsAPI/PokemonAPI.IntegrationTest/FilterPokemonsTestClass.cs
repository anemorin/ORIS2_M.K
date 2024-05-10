using System.Net;
using System.Net.Http.Json;
using PokemonAPI.Core.Models;

namespace PokemonAPI.IntegrationTest;

[TestClass] 
public class FilterPokemonsTestClass
{
    private static readonly HttpClient HttpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5022") }; 

    [TestMethod]
    public async Task GetPokemonsByFilter_ReturnsOkStatus()
    {
        // Arrange
        var filter = "fire";

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/Filter/{filter}");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
    [TestMethod]
    public async Task GetPokemonsByFilter_ReturnsFilteredPokemons()
    {
        // Arrange
        var filter = "saur";

        // Act
        var filteredPokemons = await HttpClient.GetFromJsonAsync<List<PokemonResult>>($"/api/Pokemon/Filter/{filter}");

        // Assert
        Assert.IsNotNull(filteredPokemons);
        Assert.IsTrue(filteredPokemons.Any()); // Убедимся, что есть хотя бы один покемон после фильтрации
    }
    
    [TestMethod]
    public async Task FindPokemonByName()
    {
        // Arrange
        var filter = "bulbasaur";
        bool fl = true;

        // Act
        var filteredPokemons = await HttpClient.GetFromJsonAsync<List<PokemonResult>>($"/api/Pokemon/Filter/{filter}");
        
        
        // Assert
        if (filteredPokemons!.Count == 1)
        {
            Assert.AreEqual(filteredPokemons[0].Name, filter);
        }
        else
        {
            Assert.AreEqual(2,1);
        }
    }
    
    [TestMethod]
    public async Task GetPokemonsByFilter_EmptyResult_ReturnsNoContent()
    {
        // Arrange
        var filter = "nonexistent";

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/Filter/{filter}");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
    
    [TestMethod]
    public async Task GetPokemonsByFilter_EmptyResult()
    {
        // Arrange
        var filter = "1337";

        // Act
        var response = await HttpClient.GetFromJsonAsync<List<PokemonResult>>($"/api/Pokemon/Filter/{filter}");

        // Assert
        Assert.AreEqual(0, response!.Count);
    }
    
    [TestMethod]
    public async Task GetPokemonsByFilter_InvalidFilter_ReturnsNotFound()
    {
        // Arrange
        var invalidFilter = "";

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/Filter/{invalidFilter}");

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}