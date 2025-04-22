using ReciicerAPI.Models.DTOs.Coleta;

namespace ReciicerAPI.Models.DTOs.Cliente
{
    public class ClienteReadDTO : ClienteBaseDTO
    {
        IEnumerable<ColetaBaseDTO>? Coletas { get; set; }
    }
}