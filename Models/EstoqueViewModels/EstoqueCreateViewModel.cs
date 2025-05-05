using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Models.EstoqueViewModels
{
    public class EstoqueCreateViewModel
    {
        public Estoque? Estoque { get; set; }

        public IEnumerable<PontoColeta>? PontoColetas { get; set; }
    }
}