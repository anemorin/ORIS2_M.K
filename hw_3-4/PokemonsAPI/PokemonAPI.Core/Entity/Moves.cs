namespace PokemonAPI.Core.Entity;


public class Moves
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public List<PokemonMoves> Pokemons { get; set; } = new List<PokemonMoves>();
}