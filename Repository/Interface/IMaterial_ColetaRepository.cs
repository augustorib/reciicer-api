using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IMaterial_ColetaRepository
    {
        IEnumerable<Material_Coleta> ListarMaterialColeta();  
        IEnumerable<Material_Coleta> ListarMaterialColetaMaterial();
        IEnumerable<Material_Coleta> ListarMaterialColetaPorColetaId(int ColetaId);  
        Material_Coleta ObterMaterialColetaPorId(int id);  
        void RegistrarMaterialColeta(Material_Coleta tipoMaterialColeta); 
        void ExcluirMaterialColeta(int id);
    }
}