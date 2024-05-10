using Newtonsoft.Json;
using PokemonAPI.Core.Services.Pokemons;

namespace PokemonAPI.Core.Services.ParseEntity;

public class StatJson
{
    [JsonProperty("base_stat")]
    public int BaseStat { get; set; }
    
    [JsonProperty("stat")]
    public StatInfo StatInfo { get; set; }
}