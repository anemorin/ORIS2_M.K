using System.Text.Json.Serialization;

namespace PokemonAPI.Core.Entity;

public class Types
{
    public Guid Id { get; set; }

    public string Name { get; set; } = String.Empty;
    [JsonIgnore]
    public List<PokemonTypes> Pokemon { get; set; } = new List<PokemonTypes>();
}