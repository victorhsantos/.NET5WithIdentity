using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Interfaces.Services;
using FilmesApi.Models;
using FluentResults;
using System.Linq;

namespace FilmesApi.Services
{
    public class GerenteServices : IGerenteServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GerenteServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public Result DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes
                .FirstOrDefault(gerente => gerente.Id == id);

            if (gerente == null)
                return Result.Fail("Gerente não encontrado");

            _context.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }

        public ReadGerenteDto RecuperaGerentesPorId(int id)
        {
            Gerente gerente = _context.Gerentes
                .FirstOrDefault(gerente => gerente.Id == id);

            if (gerente == null)
                return null;

            ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
            return gerenteDto;

        }
    }
}
