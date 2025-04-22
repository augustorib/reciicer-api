using System.Text.Json.Serialization;

namespace ReciicerAPI.Models.DTOs.Cliente
{
    public class ClienteUpdateDTO : ClienteBaseDTO
    {
        [JsonIgnore]
        public new int Id { get; set; }
    }
}