using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Core.Entity;
using PokemonAPI.Core.Interfaces;
using PokemonAPI.Core.Models;
using PokemonAPI.Core.Services;


namespace PokemonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokeService _pokeService;
        private readonly IDbSeeder _dbSeeder;
        private readonly ILogger<PokemonController> _logger;
    
        public PokemonController(IPokeService pokeApiService, ILogger<PokemonController> logger)
        {
            _pokeService = pokeApiService;
            _logger = logger;
        }
        
        /// <summary>
        /// Получить покемона по Id
        /// </summary>
        /// <param name="id">ID покемона</param>
        /// <returns>Покемона по Id</returns>
        
        [HttpGet("ById/{id}")]
        public Task<Pokemon> GetPokemonById([FromRoute]Guid id)
        {
            return _pokeService.GetById(id);
        }
        
        
        /// <summary>
        /// Получить покемона по имени
        /// </summary>
        /// <param name="name">Имя покемона</param>
        /// <returns>Покемон по имени</returns>
        [HttpGet("ByName/{name}")]
        public Task<PokemonFullInfo> GetPokemonByName([FromRoute]string name)
        {
            return _pokeService.GetByName(name);
        }
        
        
        /// <summary>
        /// Фильтрация покемонов по стрингу
        /// </summary>
        /// <param name="name">часть или полное имя покемона</param>
        /// <returns>Отфильтрованный список покемонов</returns>
        [HttpGet("Filter/{name}")]
        public async Task<List<PokemonWithTypesResponse>> GetByFilter([FromRoute] string name)
        {
           List<PokemonWithTypesResponse> filteredPokemons = await _pokeService.Filter(name);
           return filteredPokemons;
        }

        [HttpGet("[action]")]
        public async Task<List<Types>> GetType()
        {
            return await _pokeService.GetTypes();
        }
        
        
        /// <summary>
        /// Получить несколько покемонов 
        /// </summary>
        /// <param name="offset">кол-во покемонов</param>
        /// <returns>Список Покемонов</returns>
        
        [HttpGet("Pagination")]
        public Task<List<PokemonWithTypesResponse>> Pagination([FromQuery]int offset, int limit)
        {
            return _pokeService.ForPagination(offset, limit);
        }
        
        /// <summary>
        /// Получить всех покемонов
        /// </summary>
        /// <returns>массив покемонов</returns>
        [HttpGet("[action]")]
        public Task<List<Pokemon>> GetAllPokemons()
        {
            return _pokeService.GetAllPokemons();
        }
        
        
    }
}
