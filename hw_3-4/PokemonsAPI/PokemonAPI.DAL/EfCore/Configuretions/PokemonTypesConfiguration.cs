using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.DAL.EfCore.Configuretions;

public class PokemonTypesConfiguration : IEntityTypeConfiguration<PokemonTypes>
{
    public void Configure(EntityTypeBuilder<PokemonTypes> builder)
    {
        builder.HasKey(pt => new { pt.PokemonId, pt.TypesId });

        builder.HasOne(p => p.Pokemon)
            .WithMany(t => t.Types)
            .HasForeignKey(t => t.PokemonId);

        builder.HasOne(t => t.Types)
            .WithMany(p => p.Pokemon)
            .HasForeignKey(t => t.TypesId);
    }
}
