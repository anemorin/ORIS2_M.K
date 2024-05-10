namespace PokemonAPI.Core.Interfaces;

public interface IDbSeeder
{
    Task SeedAsync(CancellationToken cancellationToken);
}