using FilmesApi.Data.Dtos.Gerente;
using FluentResults;

namespace FilmesApi.Interfaces.Services
{
    public interface IGerenteServices
    {
        public ReadGerenteDto AdicionaGerente(CreateGerenteDto dto);
        public ReadGerenteDto RecuperaGerentesPorId(int id);
        public Result DeletaGerente(int id);
        
    }
}
