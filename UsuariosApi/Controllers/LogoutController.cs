using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsuariosApi.Interfaces.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly ILogoutServices _logoutServices;

        public LogoutController(ILogoutServices logoutServices)
        {
            _logoutServices = logoutServices;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Result result = _logoutServices.Logout();
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());
        }
    }
}
