using Newtonsoft.Json;
using PokemonAPI.Core.Services.Pokemons;

namespace PokemonAPI.Core.Services.ParseEntity;

public class Poke
{    
    [JsonProperty("results")]
    public List<PokemonInfo> PokemonJsons { get; set; }
}