using ReciicerAPI.Models.DTOs.Coleta;
using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Extensions
{
    public static class ColetaExtensions
    {
        public static ColetaBaseDTO ToColetaBaseDTO(this Coleta coleta)
        {
            return new ColetaBaseDTO
            {
                Id = coleta.Id,
                DataOperacao = coleta.DataOperacao,
                PontuacaoGanha = coleta.PontuacaoGanha
            };
        }
    }
}