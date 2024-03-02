using Newtonsoft.Json;
using Poke.Controllers.Models;

namespace Poke.Services;

public class PokemonService
{
	private const int standartPageSize = 40;
	public static int TakeCount(int? count)
	{
		return count.HasValue
				? count.Value
				: standartPageSize;
	}

	public static int SkipCount(int? page, int? count, int totalCount)
	{
		return (page.HasValue
			? page.Value * (count.HasValue
				? count.Value
				: standartPageSize)
			: count.HasValue
				? count.Value
				: totalCount) - (count.HasValue ? count.Value : 40);
	}

	public static List<Pokemon> ParseJson()
	{
		using (StreamReader r = new StreamReader("all_pokemon_list.json"))
		{
			string json = r.ReadToEnd();
			return JsonConvert.DeserializeObject<List<Pokemon>>(json);
		}
	}
}