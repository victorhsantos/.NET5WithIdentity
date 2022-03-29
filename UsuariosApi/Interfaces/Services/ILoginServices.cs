using FluentResults;
using UsuariosApi.Data.Requests;

namespace UsuariosApi.Interfaces.Services
{
    public interface ILoginServices
    {
        public Result Login(LoginRequest request);
        Result GetTokenResetPassword(GetTokenResetPasswordRequest request);
        Result ResetPassword(ResetPasswordRequest request);
    }
}
