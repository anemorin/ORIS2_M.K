using PokemonAPI.Core.Entity;

namespace PokemonAPI.Core.Models;

public class PokemonWithTypesResponse
{
    public Pokemon Pokemon { get; set; }
    
    public List<string> Types { get; set; }
}