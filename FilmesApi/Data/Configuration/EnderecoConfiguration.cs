using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmesApi.Data
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder
              .ToTable("enderecos");

            builder
                .HasKey(e => e.Id);

            builder
               .Property(a => a.Logradouro)
               .HasColumnName("logradouro")
               .HasColumnType("text");

            builder
               .Property(a => a.Bairro)
               .HasColumnName("bairro")
               .HasColumnType("text");

            builder
               .Property(a => a.Numero)
               .HasColumnName("numero")
               .HasColumnType("int");

            builder
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);
        }
    }
}
