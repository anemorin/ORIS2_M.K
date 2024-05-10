using Newtonsoft.Json;
using PokemonAPI.Core.Services.Pokemons;

namespace PokemonAPI.Core.Services.ParseEntity;

public class MovesJson
{
    [JsonProperty("move")]
    public MovesInfo MovesInfos { get; set; }
}
