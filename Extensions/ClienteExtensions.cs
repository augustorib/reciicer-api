using ReciicerAPI.Models.DTOs.Cliente;
using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Extensions
{
    public static class ClienteExtensions
    {
        public static ClienteReadDTO ToClienteReadDTO(this Cliente cliente)
        {
            return new ClienteReadDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome ?? string.Empty,
                Email = cliente.Email ?? string.Empty,
                Telefone = cliente.Telefone ?? string.Empty,
                CPF = cliente.CPF
            };
        }

        public static Cliente ToCliente(this ClienteCreateDTO clienteCreateDTO)
        {
            return new Cliente
            {
                Nome = clienteCreateDTO.Nome,
                Email = clienteCreateDTO.Email,
                Telefone = clienteCreateDTO.Telefone,
                CPF = clienteCreateDTO.CPF
            };
        }

        public static Cliente ToCliente(this ClienteUpdateDTO clienteUpdateDTO, int id)
        {
            return new Cliente
            {
                Id = id,
                Nome = clienteUpdateDTO.Nome,
                Email = clienteUpdateDTO.Email,
                Telefone = clienteUpdateDTO.Telefone,
                CPF = clienteUpdateDTO.CPF
            };
        }
               
    }
}
