
using System.Text.Json.Serialization;

namespace PokemonAPI.Core.Entity;

public class PokemonMoves
{
    public Guid PokemonId { get; set; }
    
    public Guid MovesId { get; set; }
    [JsonIgnore]
    public Pokemon Pokemon { get; set; }
    [JsonIgnore]
    public Moves Moves { get; set; }
}