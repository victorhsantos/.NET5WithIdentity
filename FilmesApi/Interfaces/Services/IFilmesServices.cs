using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Data.Dtos;
using FluentResults;

namespace FilmesApi.Interfaces.Services
{
    public interface IFilmesServices
    {
        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto);
        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria = null);
        public ReadFilmeDto RecuperaFilmesPorId(int id);
        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto);
        public Result DeletaFilme(int id);
    }
}
