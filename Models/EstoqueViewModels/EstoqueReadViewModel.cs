using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Models.EstoqueViewModels
{
    public class EstoqueReadViewModel
    {
        public Estoque? Estoque { get; set; }

        public IEnumerable<EstoqueMaterial>? EstoqueMateriais { get; set; }
    }
}