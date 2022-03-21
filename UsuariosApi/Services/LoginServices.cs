using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Requests;
using UsuariosApi.Interfaces.Services;

namespace UsuariosApi.Services
{
    public class LoginServices : ILoginServices
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginServices(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Login(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Login falhou");
        }
    }
}
