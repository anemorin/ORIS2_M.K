using Newtonsoft.Json;

namespace PokemonAPI.Core.Services.ParseEntity;

public class ParseFromJson
{
   [JsonProperty("abilities")]
   public List<AbilityJson> AbilityJsons { get; set; }   
   
   [JsonProperty("moves")]
   public List<MovesJson> MovesJsons { get; set; }
   
   [JsonProperty("sprites")]
   public OtherJson OtherJsons { get; set; }
   
   [JsonProperty("stats")]
   public List<StatJson> StatJsons { get; set; }
   
   [JsonProperty("types")]
   public List<TypesJson> TypesJsons { get; set; }
   
   [JsonProperty("height")]
   public double Height { get; set; }
   
   [JsonProperty("weight")]
   public double Weight { get; set; }
   
}







