using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Models.MaterialViewModels
{
    public class MaterialCreateViewModel
    {
        public IEnumerable<TipoMaterial>? TipoMateriais { get; set; }
        public Material? Material { get; set; }

    }
}