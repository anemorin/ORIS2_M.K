using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.DAL.EfCore.Configuretions;

public class PokemonMovesConfiguration : IEntityTypeConfiguration<PokemonMoves>
{
    public void Configure(EntityTypeBuilder<PokemonMoves> builder)
    {
        builder.HasKey(x => new { x.PokemonId, x.MovesId });

        builder.HasOne(x => x.Moves)
            .WithMany(x => x.Pokemons)
            .HasForeignKey(x => x.MovesId);

        builder.HasOne(x => x.Pokemon)
            .WithMany(x => x.Moves)
            .HasForeignKey(x => x.PokemonId);
    }
}