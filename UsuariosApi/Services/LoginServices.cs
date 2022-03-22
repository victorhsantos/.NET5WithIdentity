using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using UsuariosApi.Data.Requests;
using UsuariosApi.Interfaces.Services;

namespace UsuariosApi.Services
{
    public class LoginServices : ILoginServices
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private ITokenServices _tokenServices;

        public LoginServices(SignInManager<IdentityUser<int>> signInManager, ITokenServices tokenServices)
        {
            _signInManager = signInManager;
            _tokenServices = tokenServices;
        }

        public Result Login(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(u => u.NormalizedUserName == request.UserName.ToUpper());

                var token = _tokenServices.CreateToken(identityUser);

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }
    }
}
