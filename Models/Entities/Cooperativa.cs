using System.ComponentModel.DataAnnotations;


namespace ReciicerAPI.Models.Entities
{
    public class Cooperativa : EntidadeBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cooperativa")]
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? CNPJ { get; set; }

        public ICollection<Recolhimento>? Recolhimentos { get; set; }
    }
}