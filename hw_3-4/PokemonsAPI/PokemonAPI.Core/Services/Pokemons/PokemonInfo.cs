using Newtonsoft.Json;

namespace PokemonAPI.Core.Services.Pokemons;

public class PokemonInfo
{
    [JsonProperty("name")] 
    public string Name { get; set; } = default!;
    
    [JsonProperty("url")]
    public string? Url { get; set; } = default!;

}