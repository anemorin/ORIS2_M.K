using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.DAL.EfCore.Configuretions;

public class StatConfiguration : IEntityTypeConfiguration<Stat>
{
    public void Configure(EntityTypeBuilder<Stat> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Value)
            .IsRequired();

        builder.HasOne(x => x.Pokemon)
            .WithMany(x => x.Stats);
    }
}