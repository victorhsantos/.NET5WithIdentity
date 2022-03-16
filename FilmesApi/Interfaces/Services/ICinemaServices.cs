using System.Collections.Generic;
using FluentResults;
using FilmesAPI.Data.Dtos;

namespace FilmesApi.Interfaces.Services
{
    public interface ICinemaServices
    {       
        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto);
        public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme);
        public ReadCinemaDto RecuperaCinemasPorId(int id);
        public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto);
        public Result DeletaCinema(int id);
    }
}
