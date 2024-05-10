using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Entity;
using PokemonAPI.Core.Interfaces;
using PokemonAPI.DAL.EfCore.Configuretions;

namespace PokemonAPI.DAL.EfCore;

public class AppDbContext : DbContext, IDbContext
{
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Abilities> Abilities { get; set; }
    public DbSet<Breeding> Breedings { get; set; }
    public DbSet<Moves> Moves { get; set; }
    public DbSet<Stat> Stats { get; set; }
    public DbSet<Types> Types { get; set; }
    public DbSet<PokemonMoves> PokemonMoves { get; set; }
    public DbSet<PokemonTypes> PokemonTypes { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=pocke;Password=123456;Database=pockemon;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AbilityConfiguration());
        modelBuilder.ApplyConfiguration(new BreedingConfiguration());
        modelBuilder.ApplyConfiguration(new PokemonConfiguration());
        modelBuilder.ApplyConfiguration(new MovesConfiguration());
        modelBuilder.ApplyConfiguration(new StatConfiguration());
        modelBuilder.ApplyConfiguration(new TypesConfiguration());
        modelBuilder.ApplyConfiguration(new PokemonTypesConfiguration());
        modelBuilder.ApplyConfiguration(new PokemonMovesConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}