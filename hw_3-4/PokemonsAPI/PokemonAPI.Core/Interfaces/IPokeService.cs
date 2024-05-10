using PokemonAPI.Core.Entity;
using PokemonAPI.Core.Models;

namespace PokemonAPI.Core.Interfaces;

public interface IPokeService
{
    public Task<List<Pokemon>> GetAllPokemons();

    public Task<Pokemon> GetById(Guid id);

    public Task<PokemonFullInfo> GetByName(string name);

    public Task<List<PokemonWithTypesResponse>> Filter(string name);

    public Task<List<Types>> GetTypes();
    
    public Task<List<PokemonWithTypesResponse>> ForPagination(int offset, int limit);
}