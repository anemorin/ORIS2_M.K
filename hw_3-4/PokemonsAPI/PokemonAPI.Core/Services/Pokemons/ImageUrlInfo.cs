using Newtonsoft.Json;

namespace PokemonAPI.Core.Services.Pokemons;

public class ImageUrlInfo
{
    [JsonProperty("front_default")]
    public string ImageUrl { get; set; } = String.Empty;
}