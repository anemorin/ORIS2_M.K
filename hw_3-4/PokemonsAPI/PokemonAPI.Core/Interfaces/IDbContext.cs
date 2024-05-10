using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.Core.Interfaces;

public interface IDbContext
{
    DbSet<Pokemon> Pokemons { get; set; }
    
    DbSet<Abilities> Abilities { get; set; }
    
    DbSet<Breeding> Breedings { get; set; }
    
    DbSet<Moves> Moves { get; set; }
    
    DbSet<Stat> Stats { get; set; }
    DbSet<Types> Types { get; set; }
    DbSet<PokemonMoves> PokemonMoves { get; set; }
    DbSet<PokemonTypes> PokemonTypes { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}