using Newtonsoft.Json;
using PokemonAPI.Core.Services.Pokemons;

namespace PokemonAPI.Core.Services.ParseEntity;

public class TypesJson
{
    [JsonProperty("type")]
    public TypesInfo TypesInfos { get; set; }
}