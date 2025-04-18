using Reciicer.Models.Entities;

namespace ReciicerAPI.Models.DTOs.Cliente
{
    public class ClienteReadDTO : ClienteBaseDTO
    {
        public int Id { get; set; }
        ICollection<Coleta>? Coletas { get; set; } = new List<Coleta>();
    }
}