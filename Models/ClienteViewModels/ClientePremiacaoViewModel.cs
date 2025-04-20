using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Models.ClienteViewModels
{
    public class ClientePremiacaoViewModel
    {
        public IEnumerable<Cliente>? Clientes { get; set; }
        public IEnumerable<Premiacao>? Premiacoes { get; set; }
        public Premiacao? Premiacao { get; set; }
        public int PremiacaoId { get; set; }

    }
}