using System.Text.Json.Serialization;
using ReciicerAPI.Models.DTOs.Coleta;

namespace ReciicerAPI.Models.DTOs.Cliente
{
    public class ClienteColetasDTO : ClienteBaseDTO
    {
       [JsonPropertyOrder(10)]
       public IEnumerable<ColetaBaseDTO>? Coletas { get; set; } 
    }
}