

namespace ReciicerAPI.Models.DTOs.Cliente
{
    public abstract class ClienteBaseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? CPF { get; set; } 
    }
}