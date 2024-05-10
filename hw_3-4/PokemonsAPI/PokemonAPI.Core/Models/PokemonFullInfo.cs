using PokemonAPI.Core.Entity;

namespace PokemonAPI.Core.Models;

public class PokemonFullInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public int Order { get; set; }    
    public IEnumerable<string> Moves { get; set; }
    
    public List<Abilities> Abilities { get; set; }
    
    public List<Stat> Stat { get; set; }
    
    public List<string>? TypesList { get; set; }
    
    public Breeding Breeding { get; set; }
}