using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data.Dtos.Sessao;

namespace FilmesApi.Interfaces.Services
{
    public interface ISessaoServices
    {
        public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto);
        public ReadSessaoDto RecuperaSessoesPorId(int id);
        
    }
}
