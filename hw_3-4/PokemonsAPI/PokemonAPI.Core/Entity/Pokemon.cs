namespace PokemonAPI.Core.Entity;

public class Pokemon
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = String.Empty;

    public string ImgUrl { get; set; } = String.Empty;
    
    public int Order { get; set; }

    public List<Abilities> Abilities { get; set; } = new();

    public List<Stat> Stats { get; set; } = new();

    public List<PokemonTypes> Types { get; set; } = new();

    public List<PokemonMoves> Moves { get; set; } = new();

    public Breeding? Breeding { get; set; }


}