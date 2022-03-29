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
                var user = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(u => u.NormalizedUserName == request.UserName.ToUpper());

                var token = _tokenServices.CreateToken(user);

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result GetTokenResetPassword(GetTokenResetPasswordRequest request)
        {
            IdentityUser<int> user = GetUserByEmail(request.Email);

            if (user == null) return Result.Fail("Falha ao solicitar redefinição.");

            var tokenRecovery = _signInManager
                .UserManager
                .GeneratePasswordResetTokenAsync(user).Result;
            return Result.Ok().WithSuccess(tokenRecovery);
        }


        public Result ResetPassword(ResetPasswordRequest request)
        {
            var user = GetUserByEmail(request.Email);

            IdentityResult resultIdentity = _signInManager
                .UserManager
                .ResetPasswordAsync(user, request.Token, request.Password)
                .Result;

            if (resultIdentity.Succeeded) return Result.Ok().WithSuccess("Senha Redefinada com sucesso!");
            return Result.Fail("Houve um erro na operação.");

        }

        private IdentityUser<int> GetUserByEmail(string email)
        {
            return _signInManager
                            .UserManager
                            .Users
                            .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
