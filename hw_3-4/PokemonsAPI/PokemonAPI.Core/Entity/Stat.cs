using System.Text.Json.Serialization;

namespace PokemonAPI.Core.Entity;

public class Stat
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
   
    public double Value { get; set; }
    
    public Guid PokemonId { get; set; }
    
    [JsonIgnore]
    public Pokemon Pokemon { get; set; }
    
}