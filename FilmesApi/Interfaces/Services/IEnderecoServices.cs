using FilmesApi.Models;
using FilmesAPI.Data.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesApi.Interfaces.Services
{
    public interface IEnderecoServices
    {
        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto);
        public IEnumerable<Endereco> RecuperaEnderecos();
        public ReadEnderecoDto RecuperaEnderecosPorId(int id);
        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto);
        public Result DeletaEndereco(int id);
        
    }
}
