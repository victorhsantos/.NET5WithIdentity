using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Interfaces.Services;
using FilmesApi.Models;

namespace FilmesApi.Services
{
    public class SessaoServices : ISessaoServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes
                .FirstOrDefault(sessao => sessao.Id == id);

            if (sessao == null) return null;

            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return sessaoDto;

        }
    }
}
