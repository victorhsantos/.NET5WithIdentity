using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Interfaces.Services;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoServices _sessaoServices;

        public SessaoController(ISessaoServices sessaoServices)
        {
            _sessaoServices = sessaoServices;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            var readDTO = _sessaoServices.AdicionaSessao(dto);
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            var readDTO = _sessaoServices.RecuperaSessoesPorId(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }
    }
}
