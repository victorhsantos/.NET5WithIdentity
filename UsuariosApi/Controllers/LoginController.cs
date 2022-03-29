using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsuariosApi.Data.Requests;
using UsuariosApi.Interfaces.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var result = _loginServices.Login(request);
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpPost("/getreset-password")]
        public IActionResult GetTokenResetPassword(GetTokenResetPasswordRequest request)
        {
            Result result = _loginServices.GetTokenResetPassword(request);
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());
        }
        [HttpPost("/reset-password")]
        public IActionResult ResetPassword(ResetPasswordRequest request)
        {
            Result result = _loginServices.ResetPassword(request);
            if (result.IsFailed) return Unauthorized(result.Errors.FirstOrDefault());
            return Ok(result.Successes.FirstOrDefault());
        }
    }

}
