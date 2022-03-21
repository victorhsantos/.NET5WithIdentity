using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Interfaces.Services;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroServices : ICadastroServices
    {
        private readonly IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroServices(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result AddUser(CreateUsuarioDTO usuarioDTO)
        {
            Usuario user = _mapper.Map<Usuario>(usuarioDTO);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            var resultadoIdentity = _userManager.CreateAsync(userIdentity, usuarioDTO.Password);
            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");

        }
    }
}
