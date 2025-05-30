﻿using System.Linq;
using System.Collections.Generic;
using FilmesApi.Data;
using FilmesApi.Interfaces.Services;
using FilmesAPI.Data.Dtos;
using FilmesApi.Models;
using AutoMapper;
using FluentResults;

namespace FilmesApi.Services
{
    public class CinemaServices : ICinemaServices
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CinemaServices(AppDbContext Context, IMapper Mapper)
        {
            _context = Context;
            _mapper = Mapper;
        }

        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null) return null;

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;

                cinemas = query.ToList();
            }

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return null;
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return Result.Fail("Cinema não encontrado!");
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) 
                return Result.Fail("Cinema não encontrado!");            
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

    }
}
