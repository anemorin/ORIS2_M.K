using Microsoft.Extensions.DependencyInjection;
using PokemonAPI.Core.Interfaces;
using PokemonAPI.Core.Services;

namespace PokemonAPI.Core;

public static class Entry
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
            throw new ArgumentNullException(nameof(serviceCollection));

        serviceCollection.AddLogging();
        serviceCollection.AddScoped<IDbSeeder, DbSeeder>();
        serviceCollection.AddScoped<IPokeService, PokeService>();
        
        return serviceCollection;
    }
}