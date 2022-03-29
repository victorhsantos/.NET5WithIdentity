using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models;

namespace UsuariosApi.Interfaces.Services
{
    public interface ITokenServices
    {
        public Token CreateToken(CustomIdentityUser user, string role);
    }
}
