using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Entity;
using PokemonAPI.Core.Interfaces;
using PokemonAPI.Core.Models;

namespace PokemonAPI.Core.Services;

public class PokeService : IPokeService
{
    private readonly IDbContext _dbContext;

    public PokeService(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<List<Pokemon>> GetAllPokemons()
    {
        return await _dbContext.Pokemons.ToListAsync();
    }
    

    public async Task<Pokemon> GetById(Guid id)
    {
        return await _dbContext.Pokemons.FirstOrDefaultAsync(x => x.Id == id) ?? new Pokemon();
        
    }

    public async Task<PokemonFullInfo> GetByName(string name)
    {
        var poke = await _dbContext.Pokemons
            .Include(x => x.Abilities)
            .Include(x => x.Breeding)
            .Include(x => x.Moves)
            .ThenInclude(m => m.Moves)
            .Include(x => x.Stats)
            .Include(x => x.Types)
            .ThenInclude(x => x.Types)
            .FirstOrDefaultAsync(x => x.Name == name) ?? new Pokemon();
        
        return new PokemonFullInfo()
        {
            Id = poke.Id,
            ImgUrl = poke.ImgUrl,
            Name = poke.Name,
            Order = poke.Order,
            Abilities = poke.Abilities,
            Breeding = poke.Breeding,
            Stat = poke.Stats,
            TypesList = poke.Types.Select(t => t.Types.Name).ToList(),
            
            Moves = poke.Moves.Select(m => m.Moves.Name)
        };

    }

    public async Task<List<Types>> GetTypes()
    {
        return await _dbContext.Types.ToListAsync();
    }


    public async Task<List<PokemonWithTypesResponse>> ForPagination(int offset, int limit)
    {
        var pokemons = await _dbContext.Pokemons
            .Include(p => p.Types)
            .ThenInclude(pt => pt.Types)
            .Skip(offset)
            .Take(limit)
            .OrderBy(x => x.Order)
            .ToListAsync();

        var pokemonResponses = new List<PokemonWithTypesResponse>();

        foreach (var pokemon in pokemons)
        {
            var pokemonResponse = new PokemonWithTypesResponse
            {
                Pokemon = pokemon,
                Types = pokemon.Types.Select(pt => pt.Types.Name).ToList()
            };

            pokemonResponses.Add(pokemonResponse);
        }

        return pokemonResponses;
    }
    public async Task<List<PokemonWithTypesResponse>> Filter(string name)
    {
        var pokemons = await ForPagination(0, 1302);
        var filter = new List<PokemonWithTypesResponse>();
        foreach (var pokemon in pokemons)
        {
            if (pokemon.Pokemon.Name.Contains(name))
            {
                filter.Add(pokemon);
            }
        }

        return filter;
    }
}
