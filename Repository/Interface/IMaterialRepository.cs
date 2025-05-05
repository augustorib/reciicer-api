using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> ListarMaterial(); 
        Material ObterMaterialPorId(int id);  
        void RegistrarMaterial(Material material); 
        void AtualizarMaterial(Material material);
        void ExcluirMaterial(int id);
    }
}