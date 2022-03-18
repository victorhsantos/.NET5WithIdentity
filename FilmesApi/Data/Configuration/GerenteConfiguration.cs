using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmesApi.Data.Configuration
{
    public class GerenteConfiguration : IEntityTypeConfiguration<Gerente>
    {
        public void Configure(EntityTypeBuilder<Gerente> builder)
        {
            builder
                .ToTable("gerentes");

            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Nome)
                .HasColumnName("nome")
                .HasColumnType("text")
                .IsRequired();
        }
    }
}
