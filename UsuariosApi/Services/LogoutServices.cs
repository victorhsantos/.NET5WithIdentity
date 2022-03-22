using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Interfaces.Services;

namespace UsuariosApi.Services
{
    public class LogoutServices : ILogoutServices
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public LogoutServices(SignInManager<IdentityUser<int>> signInManager)
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
