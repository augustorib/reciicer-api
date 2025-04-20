using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Models.ColetaViewModels
{
    public class ColetaReadViewModel
    {
      public Coleta? Coleta { get; set; }
      public IEnumerable<Material_Coleta>? Material_Coletas { get; set; }

    }
}