using Microsoft.EntityFrameworkCore;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmesApi.Data.Configuration
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder
                .ToTable("cinemas");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId);
        }
    }
}
