using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.DAL.EfCore.Configuretions;

public class BreedingConfiguration : IEntityTypeConfiguration<Breeding>
{
    public void Configure(EntityTypeBuilder<Breeding> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Height)
            .IsRequired();

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.HasOne(x => x.Pokemon)
            .WithOne(x => x.Breeding);
    }
}