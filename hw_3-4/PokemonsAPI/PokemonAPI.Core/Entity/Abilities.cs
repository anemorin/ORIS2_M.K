using System.Text.Json.Serialization;

namespace PokemonAPI.Core.Entity;

public class Abilities
{
    public Guid Id { get; set; }

    public string Name { get; set; } = String.Empty;
    
    public Guid PokemonId { get; set; }
    
    [JsonIgnore]
    public Pokemon Pokemon { get; set; }
    
}