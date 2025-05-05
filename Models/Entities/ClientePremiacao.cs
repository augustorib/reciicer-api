using System.ComponentModel.DataAnnotations;

namespace ReciicerAPI.Models.Entities
{
    public class ClientePremiacao : EntidadeBase
    {

        [Key]
        public int Id { get; set; }
        public DateTime DataOperacao { get; set;}
        public int ClienteId { get; set; }
        public int PremiacaoId { get; set; }

        //Navigation 
        public Cliente? Cliente { get; set; }
        public Premiacao? Premiacao { get; set; }
    }
}