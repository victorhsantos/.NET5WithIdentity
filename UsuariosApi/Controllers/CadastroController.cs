using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Interfaces.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroServices _services;

        public CadastroController(ICadastroServices services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDTO createUsuarioDTO)
        {
            var result = _services.AddUser(createUsuarioDTO);
            if (result.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}
