using Microsoft.AspNetCore.Mvc;
using Poke.Controllers.Models;
using Poke.Services;

namespace Poke.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private static List<Pokemon> items;

        public PokemonController()
        {
            items = PokemonService.ParseJson();
        }

        /// <summary>
        /// Метод для получения всех покемонов
        /// </summary>
        /// <returns> Возвращает список всех покемонов в системе </returns>
        [HttpGet]
        public AllPokemonResponse getAll([FromQuery] int page, [FromQuery] int? count)
        {
            var totalCount = items.Count();
            return new AllPokemonResponse()
            {
                totalCount = totalCount,
                pokemons = items
                    .Skip(PokemonService.SkipCount(page, count, totalCount))
                    .Take(PokemonService.TakeCount(count))
                    .Select((poc) =>
                    {
                        var imageUrl = poc.sprites.other.home.front_default ?? poc.sprites.front_default;
                        return new
                        {
                            poc.id, poc.name, imageUrl, poc.types
                        };
                    })
            };
        }

        // GET: api/Pokemon/pikachu
        [HttpGet("{nameOrId}")]
        public Pokemon getByIdOrName([FromRoute] string nameOrId)
        {
            int id = 0;
            if (int.TryParse(nameOrId, out id))
            {
                return items.FirstOrDefault((pok) => pok.id == id);
            }
            return items.FirstOrDefault((pok) => pok.name.Equals(nameOrId, StringComparison.OrdinalIgnoreCase));
        }

        // GET: api/Pokemon/pikachu
        [HttpGet("GetByFilter")]
        public AllPokemonResponse getByFilter([FromQuery]string? search, [FromQuery] int page, [FromQuery] int? count)
        {
            var totalCount = items.Count();
            var filteredItems = items
                .Select(
                    (poc) =>
                    {
                        var imageUrl = poc.sprites.other.home.front_default ?? poc.sprites.front_default;
                        return new { poc.id, poc.name, imageUrl, poc.types };
                    })
                .Where((pok) => pok.name.Contains(search, StringComparison.OrdinalIgnoreCase));
                
            return new AllPokemonResponse()
            {
                totalCount = filteredItems.Count(),
                pokemons = filteredItems.Skip(PokemonService.SkipCount(page, count, totalCount))
                    .Take(PokemonService.TakeCount(count)),
            };
        }
    }
}
