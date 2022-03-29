using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Interfaces.Services;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LogoutServices : ILogoutServices
    {
        private readonly SignInManager<CustomIdentityUser> _signInManager;

        public LogoutServices(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Logout()
        {
            var resultIdentity = _signInManager.SignOutAsync();
            if (resultIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout falhou");
        }
    }
}
