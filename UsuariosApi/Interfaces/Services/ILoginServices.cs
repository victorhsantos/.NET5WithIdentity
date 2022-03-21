using FluentResults;
using UsuariosApi.Data.Requests;

namespace UsuariosApi.Interfaces.Services
{
    public interface ILoginServices
    {
        public Result Login(LoginRequest request);
    }
}
