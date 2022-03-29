using Microsoft.AspNetCore.Mvc;
using FilmesApi.Interfaces.Services;
using FilmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmesServices _filmesServices;

        public FilmeController(IFilmesServices filmesServices)
        {
            _filmesServices = filmesServices;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var readDTO = _filmesServices.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var readDTO = _filmesServices.RecuperaFilmes(classificacaoEtaria);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var readDTO = _filmesServices.RecuperaFilmesPorId(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var result = _filmesServices.AtualizaFilme(id, filmeDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var result = _filmesServices.DeletaFilme(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}