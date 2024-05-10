using System.Net;
using System.Net.Http.Json;
using PokemonAPI.Core.Models;

namespace PokemonAPI.IntegrationTest;

[TestClass] 
public class GetAllPokemonsTestClass
{
    private static readonly HttpClient HttpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5022") }; 
    
    [TestMethod]
    public async Task GetAllPokemons_ReturnsOkStatus()
    {
        // Act
        var response = await HttpClient.GetAsync("/api/Pokemon/poke");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
    
    [TestMethod]
    public async Task GetAllPokemons_ReturnsAllPokemons()
    {
        // Act
        var allPokemons = await HttpClient.GetFromJsonAsync<PokemonResponse>("/api/Pokemon/poke");

        // Assert
        Assert.IsNotNull(allPokemons);
        Assert.IsTrue(allPokemons.Results!.Any()); // Убедимся, что есть хотя бы один покемон в ответе
    }
    
    [TestMethod]
    public async Task ReturnAllPokemons()
    {
        // Act
        var myPokemons = await HttpClient.GetFromJsonAsync<PokemonResponse>("/api/Pokemon/poke");
        var apiPokemons = await HttpClient.GetFromJsonAsync<PokemonResponse>("https://pokeapi.co/api/v2/pokemon?limit=1302");

        // Assert
        
        Assert.AreEqual(myPokemons!.Count, apiPokemons!.Count); // Убедимся, что есть хотя бы один покемон в ответе
    }
    
    [TestMethod]
    public async Task PokemonMatching()
    {
        // Arrange
        var myPokemons = await HttpClient.GetFromJsonAsync<PokemonResponse>("/api/Pokemon/poke");
        var apiPokemons = await HttpClient.GetFromJsonAsync<PokemonResponse>("https://pokeapi.co/api/v2/pokemon?limit=1302");

        var myPokemonsName = myPokemons!.Results;
        var apiPokemonName = apiPokemons!.Results;
        bool fl = true;
        Console.WriteLine(fl);
        // Act
        for (int i = 0; i < myPokemons.Count; i++)
        {
            Console.WriteLine(myPokemonsName![i].Name);
            Console.WriteLine(i);
            if (myPokemonsName![i].Name != apiPokemonName![i].Name)
            {
                Console.WriteLine(myPokemonsName[i].Name);
                fl = false;
                break;
            }
        }
        
        // Assert
        Assert.IsTrue(fl);
    }
}