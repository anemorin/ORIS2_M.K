using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entity;

namespace PokemonAPI.DAL.EfCore.Configuretions;

public class TypesConfiguration : IEntityTypeConfiguration<Types>
{
    public void Configure(EntityTypeBuilder<Types> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

    }
}