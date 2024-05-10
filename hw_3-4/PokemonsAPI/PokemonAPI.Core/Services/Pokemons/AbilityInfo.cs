using Newtonsoft.Json;

namespace PokemonAPI.Core.Services.Pokemons;

public class AbilityInfo
{
    [JsonProperty("name")]
    public string Name { get; set; } = String.Empty;
}
