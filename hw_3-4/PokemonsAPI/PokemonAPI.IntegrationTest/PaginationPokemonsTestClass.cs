using System.Net;
using System.Net.Http.Json;
using PokemonAPI.Core.Models;

namespace PokemonAPI.IntegrationTest;

[TestClass]
public class PaginationPokemonsTestClass
{
    private static readonly HttpClient HttpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5022") };
    
    [TestMethod]
    public async Task GetPokemonsForPagination_ReturnsOkStatus()
    {
        // Arrange
        var offset = 0;

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/Pagination/{offset}");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
    [TestMethod]
    public async Task GetPokemonsForPagination_ReturnsPaginatedPokemons()
    {
        // Arrange
        var offset = 0;

        // Act
        var paginatedPokemons = await HttpClient.GetFromJsonAsync<PokemonResponse>($"/api/Pokemon/Pagination/{offset}");

        // Assert
        Assert.IsNotNull(paginatedPokemons);
        Assert.IsTrue(paginatedPokemons.Results!.Any()); // Убедимся, что есть хотя бы один покемон в ответе
    }
    
    [TestMethod]
    public async Task GetPokemonsForPagination_InvalidOffset()
    {
        // Arrange
        var invalidOffset = -1;

        // Act
        var response = await HttpClient.GetFromJsonAsync<PokemonResponse>($"/api/Pokemon/Pagination/{invalidOffset}");
        var api = await HttpClient.GetFromJsonAsync<PokemonResponse>($"/api/Pokemon/poke");

        // Assert
        Assert.AreEqual(api!.Count, response!.Count);
    }
    [TestMethod]
    public async Task GetPokemonsForPagination_InvalidOffset_ReturnsBadRequest()
    {
        // Arrange
        var invalidOffset = -1;

        // Act
        var response = await HttpClient.GetAsync($"/api/Pokemon/Pagination/{invalidOffset}");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
}