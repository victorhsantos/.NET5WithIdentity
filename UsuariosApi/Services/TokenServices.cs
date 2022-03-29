using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Interfaces.Services;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class TokenServices : ITokenServices
    {
        public Token CreateToken(CustomIdentityUser user, string role)
        {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.DateOfBirth, user.DataNascimento.ToString())
            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("fd6h546sf8kj71km3hm19h87jd61mb36c7k6dh13d8yj43hbj06gy8")
                );

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            
            return new Token(tokenString);
        }
    }
}
