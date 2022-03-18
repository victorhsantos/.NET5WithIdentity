using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmesApi.Data.Configuration
{
    public class SessoesConfiguration : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder
                .ToTable("sessoes");

            builder
                .HasKey(x => x.Id);

            builder
                .Property<DateTime>(x => x.HorarioDeEncerramento)
                .HasColumnName("HorarioDeEncerramento")
                .HasColumnType("datetime")
                .IsRequired();
           
            builder
               .HasOne(sessao => sessao.Filme)
               .WithMany(filme => filme.Sessoes)
               .HasForeignKey(sessao => sessao.FilmeId);

            builder
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);
        }
    }
}
