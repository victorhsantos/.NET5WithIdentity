using FluentResults;
using UsuariosApi.Data.Dtos;

namespace UsuariosApi.Interfaces.Services
{
    public interface ICadastroServices
    {
        public Result AddUser(CreateUsuarioDTO usuarioDTO);
    }
}
