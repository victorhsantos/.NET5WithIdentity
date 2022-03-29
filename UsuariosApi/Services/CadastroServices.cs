﻿using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Web;
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
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IEmailServices _emailServices;

        public CadastroServices(IMapper mapper,
            UserManager<IdentityUser<int>> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IEmailServices emailServices)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailServices = emailServices;
        }


        public Result AddUser(CreateUsuarioDTO usuarioDTO)
        {
            Usuario user = _mapper.Map<Usuario>(usuarioDTO);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);            
            var resultadoIdentity = _userManager.CreateAsync(userIdentity, usuarioDTO.Password).Result;

            var createRoleResult = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;
            var userRoleResult = _userManager.AddToRoleAsync(userIdentity, "admin").Result;
            
            
            if (resultadoIdentity.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                
                _emailServices.SendEmail(
                    new[] { userIdentity.Email }, 
                    "Link de Ativação", 
                    userIdentity.Id, 
                    encodedCode);
                
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
