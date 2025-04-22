using System.Text.Json.Serialization;

namespace ReciicerAPI.Models.DTOs.Cliente
{
    public class ClienteCreateDTO : ClienteBaseDTO
    {
        [JsonIgnore]
        public new int Id { get; set; }
    }
}