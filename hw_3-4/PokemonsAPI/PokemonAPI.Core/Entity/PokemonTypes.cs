
using System.Text.Json.Serialization;

namespace PokemonAPI.Core.Entity;

public class PokemonTypes
{
    public Guid PokemonId { get; set; }
    
    public Guid TypesId { get; set; }
    [JsonIgnore]
    public Pokemon Pokemon { get; set; } = null!; 
    [JsonIgnore]
    public Types Types { get; set; } = null!;
}