using FilmesApi.Data.Dtos.Gerente;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Interfaces.Services;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteServices _gerenteServices;

        public GerenteController(IGerenteServices gerenteServices)
        {
            _gerenteServices = gerenteServices;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto dto)
        {
            var readDTO = _gerenteServices.AdicionaGerente(dto);
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            var readDTO = _gerenteServices.RecuperaGerentesPorId(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            var result = _gerenteServices.DeletaGerente(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
