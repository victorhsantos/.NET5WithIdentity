using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Interfaces.Services;
using FilmesApi.Models;
using FilmesAPI.Data.Dtos;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class EnderecoServices : IEnderecoServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EnderecoServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            
            if (endereco == null)            
                return Result.Fail("Endereco não encontrado!");
            
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            
            if (endereco == null)
                return Result.Fail("Endereco não encontrado!");
            
            _context.Remove(endereco);
            _context.SaveChanges();
            
            return Result.Ok();
        }

        public IEnumerable<Endereco> RecuperaEnderecos()
        {
            return _context.Enderecos;
        }

        public ReadEnderecoDto RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos
                .FirstOrDefault(endereco => endereco.Id == id);

            if (endereco == null)
                return null;

            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return enderecoDto;

        }
    }
}
