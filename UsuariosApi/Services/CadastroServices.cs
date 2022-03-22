using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Interfaces.Services;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroServices : ICadastroServices
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly IEmailServices _emailServices;

        public CadastroServices(IMapper mapper, 
            UserManager<IdentityUser<int>> userManager, 
            IEmailServices emailServices)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailServices = emailServices;
        }


        public Result AddUser(CreateUsuarioDTO usuarioDTO)
        {
            Usuario user = _mapper.Map<Usuario>(usuarioDTO);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            var resultadoIdentity = _userManager.CreateAsync(userIdentity, usuarioDTO.Password);
            if (resultadoIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;

                _emailServices.SendEmail(new[] { userIdentity.Email }, "Link de Ativação", userIdentity.Id, code);
                
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");

        }
        public Result ActiveAccount(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UserId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.Code).Result;

            if (identityResult.Succeeded) return Result.Ok();

            return Result.Fail("Falha ao ativar usuário.");


        }
    }
}
