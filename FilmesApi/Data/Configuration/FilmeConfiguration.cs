using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmesApi.Data.Configuration
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder
                .ToTable("filmes");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(f => f.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("text")
                .IsRequired();

            builder
                .Property(f => f.Duracao)
                .HasColumnName("duracao")
                .HasColumnType("int")
                .IsRequired();                

            builder
                .Property(f => f.Diretor)
                .HasColumnName("diretor")
                .HasColumnType("varchar(100)");

            builder
                .Property(f => f.Genero)
                .HasColumnName("genero")
                .HasColumnType("text");

            builder
                .Property(f => f.ClassificacaoEtaria)
                .HasColumnName("ClassificacaoEtaria")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
