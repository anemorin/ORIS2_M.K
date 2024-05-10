using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Entity;
using PokemonAPI.Core.Interfaces;

namespace PokemonAPI.DAL.EfCore.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly AppDbContext _dbContext;

    public PokemonRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Pokemon>> GetAll() =>  
        await _dbContext.Pokemons.AsNoTracking().ToListAsync();
    
    public async Task<Pokemon> GetById(Guid id)
    {
        return await _dbContext.Pokemons.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) 
               ?? null!;
    }

    public async Task<Pokemon> GetByName(string name)
    {
        return await _dbContext.Pokemons.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name) ?? new Pokemon();
    }

    public async Task<Pokemon> GetByOrder(int order)
    {
        return await _dbContext.Pokemons.AsNoTracking().FirstOrDefaultAsync(x => x.Order == order) 
               ?? null!;
    }

    public async Task Add(Pokemon pokemon)
    {
        var poke = await _dbContext.Pokemons.FirstOrDefaultAsync(x => x.Name == pokemon.Name);
        if (poke == null)
        {
            await _dbContext.Pokemons.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task Delete(int order)
    {
        var pokemon = await _dbContext.Pokemons
            .Where(x => x.Order == order)
            .ExecuteDeleteAsync();

        await _dbContext.SaveChangesAsync();
    }

    // public async Task Delete(int order)
    // {
    //     var pokemon = await _dbContext.Pokemons
    //         .FirstOrDefaultAsync(x => x.Order == order);
    //
    //     if (pokemon != null)
    //     {
    //         _dbContext.Pokemons.Remove(pokemon);
    //         await _dbContext.SaveChangesAsync();
    //     }
    // }

    public async Task Update(Pokemon pokemon)
    {
        var poke = await _dbContext.Pokemons
            .Where(x => x.Order == pokemon.Order)
            .ExecuteUpdateAsync(c => c
                .SetProperty(s => s.Order, pokemon.Order)
                .SetProperty(s => s.Name, pokemon.Name)
                .SetProperty(s => s.ImgUrl, pokemon.ImgUrl));

        await _dbContext.SaveChangesAsync();
    }
}