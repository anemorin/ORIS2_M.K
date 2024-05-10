using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.DAL.EfCore.Configuretions;

public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Order)
            .IsRequired();

        builder.Property(x => x.ImgUrl)
            .IsRequired();

        builder.HasMany(x => x.Stats)
            .WithOne(s => s.Pokemon)
            .HasForeignKey(x => x.PokemonId);

        builder.HasOne(x => x.Breeding)
            .WithOne(b => b.Pokemon)
            .HasForeignKey<Breeding>(b => b.PokemonId);

        builder.HasMany(x => x.Abilities)
            .WithOne(a => a.Pokemon)
            .HasForeignKey(x => x.PokemonId);
        
    }
}