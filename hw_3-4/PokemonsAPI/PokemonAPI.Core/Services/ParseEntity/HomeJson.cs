using Newtonsoft.Json;
using PokemonAPI.Core.Services.Pokemons;

namespace PokemonAPI.Core.Services.ParseEntity;

public class HomeJson
{
    [JsonProperty("home")]
    public ImageUrlInfo Home { get; set; }
}