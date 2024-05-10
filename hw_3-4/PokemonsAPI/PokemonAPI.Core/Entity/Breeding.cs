using System.Text.Json.Serialization;

namespace PokemonAPI.Core.Entity;

public class Breeding
{
    public Guid Id { get; set; }
    
    public double Weight { get; set; }
    
    public double Height { get; set; }

    [JsonIgnore]
    public Pokemon Pokemon { get; set; } = default!;
    
    public Guid PokemonId { get; set; }
}