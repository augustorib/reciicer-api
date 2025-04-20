
using System.ComponentModel.DataAnnotations;

namespace ReciicerAPI.Models.Entities
{
    public class EstoqueMaterial : EntidadeBase
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public int Peso { get; set; }

        public int EstoqueId { get; set; }

        public int MaterialId { get; set; }


        public Material? Material { get; set; }

        public Estoque? Estoque { get; set; }

        public ICollection<RecolhimentoEstoqueMaterial>? RecolhimentoEstoqueMateriais { get; set; }

    }
}