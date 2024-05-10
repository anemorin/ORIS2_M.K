using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.DAL.EfCore.Configuretions;

public class AbilityConfiguration : IEntityTypeConfiguration<Abilities>
{
    public void Configure(EntityTypeBuilder<Abilities> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.HasOne(x => x.Pokemon)
            .WithMany(x => x.Abilities);
        
    }
}