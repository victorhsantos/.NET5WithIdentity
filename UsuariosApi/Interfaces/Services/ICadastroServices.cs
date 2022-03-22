using FluentResults;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;

namespace UsuariosApi.Interfaces.Services
{
    public interface ICadastroServices
    {
        public Result AddUser(CreateUsuarioDTO usuarioDTO);
        public Result ActiveAccount(AtivaContaRequest request);
    }
}
