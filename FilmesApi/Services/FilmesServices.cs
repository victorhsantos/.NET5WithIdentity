using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Interfaces.Services;
using FilmesAPI.Data.Dtos;
using FilmesApi.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class FilmesServices : IFilmesServices
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public FilmesServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            
            if (filme == null)            
                return Result.Fail("Filme não encontrado!");
            
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            
            if (filme == null)
                return Result.Fail("Filme não encontrado!");

            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria = null)
        {
            List<Filme> filmes;

            if (classificacaoEtaria == null)
                filmes = _context.Filmes
                    .ToList();
            else
                filmes = _context.Filmes
                    .Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria)
                    .ToList();

            if (filmes == null)
                return null;

            return _mapper.Map<List<ReadFilmeDto>>(filmes);

        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return null;
            
            ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return filmeDto;

        }
    }
}
