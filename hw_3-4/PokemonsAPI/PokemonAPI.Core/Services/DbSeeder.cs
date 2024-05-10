using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PokemonAPI.Core.Entity;
using PokemonAPI.Core.Interfaces;
using PokemonAPI.Core.Services.ParseEntity;


namespace PokemonAPI.Core.Services;


public class DbSeeder : IDbSeeder
{
    private readonly HttpClient _httpClient;

    private readonly IDbContext _dbContext;
    
    public DbSeeder(IDbContext dbContext, HttpClient client)
    {
        _httpClient = client;
         _dbContext = dbContext;
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        using var response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=1302", cancellationToken);
        int order = 0;
        if (response.IsSuccessStatusCode)
        {
            var jsonPoke = await response.Content.ReadAsStringAsync(cancellationToken);
            var desPoke = JsonConvert.DeserializeObject<Poke>(jsonPoke);
            
            foreach (var pokemonJson in desPoke!.PokemonJsons)
            {
                order++;
                using var pokeInfo = await _httpClient.GetAsync(pokemonJson.Url,cancellationToken);
                if (pokeInfo.IsSuccessStatusCode)
                {
                    var json = await pokeInfo.Content.ReadAsStringAsync(cancellationToken);
                    var des = JsonConvert.DeserializeObject<ParseFromJson>(json);
                    var pokemon = new Pokemon() 
                    {
                        Name = pokemonJson.Name,
                        ImgUrl = des!.OtherJsons.Home.Home.ImageUrl ?? "undefined",
                        Order = order
                    };
                    
                    await _dbContext.Breedings.AddAsync(new Breeding()
                    {
                        Height = des.Height,
                        Weight = des.Weight,
                        PokemonId = pokemon.Id,
                        Pokemon = pokemon
                    },cancellationToken);

                    
                    await _dbContext.Pokemons.AddAsync(pokemon,cancellationToken);
                    await AddStatAsync(des.StatJsons.Where(stats => stats.StatInfo.Name != "special-defense" && stats.StatInfo.Name != "special-attack")
                        .ToList(), pokemon, cancellationToken);
                    await AddMovesAsync(des.MovesJsons.Take(6).ToList(), pokemon, cancellationToken); 
                    await AddAbilitiesAsync(des.AbilityJsons, pokemon, cancellationToken); 
                    await AddTypesAsync(des.TypesJsons, pokemon, cancellationToken);
                    
                   
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
            }
        }    

    }
    private async Task AddStatAsync(List<StatJson> statJson,Pokemon pokemon, CancellationToken cancellationToken)
    {
        
        foreach (var stats in statJson)
        {
            await _dbContext.Stats.AddAsync(new Stat()
            {
                Name = stats.StatInfo.Name,
                Value = stats.BaseStat,
                PokemonId = pokemon.Id,
                Pokemon = pokemon
            },cancellationToken);

        }
    }
    
    private async Task AddMovesAsync(List<MovesJson> movesJson, Pokemon pokemon, CancellationToken cancellationToken)
    {
        foreach (var moves in movesJson)
        {
            var existingMoves = await _dbContext.Moves.FirstOrDefaultAsync(x => x.Name == moves.MovesInfos.Name,cancellationToken);

            if (existingMoves == null)
            {
                var newMove = new Moves() { Name = moves.MovesInfos.Name};
                await _dbContext.Moves.AddAsync(newMove, cancellationToken);

                await _dbContext.PokemonMoves.AddAsync(new PokemonMoves()
                {
                    PokemonId = pokemon.Id,
                    MovesId = newMove.Id,
                    Moves = newMove,
                    Pokemon = pokemon
                },cancellationToken);
            }
            else
            {
                await _dbContext.PokemonMoves.AddAsync(new PokemonMoves()
                {
                    PokemonId = pokemon.Id,
                    Pokemon = pokemon,
                    MovesId = existingMoves.Id,
                    Moves = existingMoves
                },cancellationToken);
            }
        }
    }
    private async Task AddAbilitiesAsync(List<AbilityJson> abilityJsons, Pokemon pokemon, CancellationToken cancellationToken)
    {
        foreach (var ability in abilityJsons)
        {
            await _dbContext.Abilities.AddAsync(new Abilities()
            {
                PokemonId = pokemon.Id,
                Name = ability.AbilityInfos.Name,
                Pokemon = pokemon
            }, cancellationToken);
        }
    }
    private async Task AddTypesAsync(List<TypesJson> typesJson, Pokemon pokemon, CancellationToken cancellationToken)
    {
        foreach (var typeJson in typesJson)
        {
            var existingType = await _dbContext.Types.FirstOrDefaultAsync(x => x.Name == typeJson.TypesInfos.Name,
                cancellationToken);
        
            if (existingType == null)
            {
                var newType = new Types { Name = typeJson.TypesInfos.Name };
                await _dbContext.Types.AddAsync(newType, cancellationToken);
                await _dbContext.PokemonTypes.AddAsync(new PokemonTypes()
                {
                    TypesId = newType.Id,
                    PokemonId = pokemon.Id,
                    Types = newType,
                    Pokemon = pokemon
                }, cancellationToken);
            }
            else
            {
                await _dbContext.PokemonTypes.AddAsync(new PokemonTypes()
                {
                    TypesId = existingType.Id,
                    PokemonId = pokemon.Id,
                    Types = existingType,
                    Pokemon = pokemon
                }, cancellationToken);
            }
        }
    }
}