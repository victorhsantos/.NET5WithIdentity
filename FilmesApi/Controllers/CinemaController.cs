using Microsoft.AspNetCore.Mvc;
using FilmesApi.Interfaces.Services;
using FilmesAPI.Data.Dtos;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaServices _cinemaServices;

        public CinemaController(ICinemaServices CinemaServices)
        {
            _cinemaServices = CinemaServices;
        }


        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            var readDTO = _cinemaServices.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            var readDto = _cinemaServices.RecuperaCinemas(nomeDoFilme);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            var readDTO = _cinemaServices.RecuperaCinemasPorId(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            var result = _cinemaServices.AtualizaCinema(id, cinemaDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            var result = _cinemaServices.DeletaCinema(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
