using Newtonsoft.Json;
using PokemonAPI.Core.Services.Pokemons;

namespace PokemonAPI.Core.Services.ParseEntity;

public class AbilityJson
{
    [JsonProperty("ability")]
    public AbilityInfo AbilityInfos { get; set; }
  
}