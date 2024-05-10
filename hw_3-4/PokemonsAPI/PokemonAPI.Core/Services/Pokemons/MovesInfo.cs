using Newtonsoft.Json;

namespace PokemonAPI.Core.Services.Pokemons;

public class MovesInfo
{
    [JsonProperty("name")]
    public string Name { get; set; } = String.Empty;
   
    [JsonProperty("url")] 
    public string Url { get; set; } = String.Empty;
}