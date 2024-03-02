namespace Poke.Controllers.Models;

public class AllPokemonResponse
{
	public int totalCount { get; set; }

	public IEnumerable<Object> pokemons { get; set; }
}