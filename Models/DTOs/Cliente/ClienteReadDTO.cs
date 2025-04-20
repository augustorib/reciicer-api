using ReciicerAPI.Models.DTOs.Coleta;

namespace ReciicerAPI.Models.DTOs.Cliente
{
    public class ClienteReadDTO : ClienteBaseDTO
    {
        public int Id { get; set; }
        IEnumerable<ColetaBaseDTO>? Coletas { get; set; }
    }
}