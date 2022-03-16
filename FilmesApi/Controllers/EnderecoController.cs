using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesApi.Interfaces.Services;
using FilmesApi.Models;
using FilmesAPI.Data.Dtos;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoServices _enderecoServices;

        public EnderecoController(IEnderecoServices enderecoServices)
        {
            _enderecoServices = enderecoServices;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var readDTO = _enderecoServices.AdicionaEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readDTO.Id }, readDTO);
        }

        [HttpGet]
        public IEnumerable<Endereco> RecuperaEnderecos()
        {
            return _enderecoServices.RecuperaEnderecos();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            var readDTO = _enderecoServices.RecuperaEnderecosPorId(id);
            if (readDTO == null) return NotFound();
            return Ok(readDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var result = _enderecoServices.AtualizaEndereco(id, enderecoDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var result = _enderecoServices.DeletaEndereco(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}