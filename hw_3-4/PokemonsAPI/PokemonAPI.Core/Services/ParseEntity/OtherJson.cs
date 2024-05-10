using Newtonsoft.Json;

namespace PokemonAPI.Core.Services.ParseEntity;

public class OtherJson
{
    [JsonProperty("other")]
    public HomeJson Home { get; set; }
}