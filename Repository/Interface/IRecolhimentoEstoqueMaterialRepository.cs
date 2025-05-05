

using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IRecolhimentoEstoqueMaterialRepository
    {
        IEnumerable<RecolhimentoEstoqueMaterial> ListarRecolhimentoEstoqueMaterial();    
        RecolhimentoEstoqueMaterial ObterRecolhimentoEstoqueMaterialPorId(int id);  
        void AtualizarRecolhimentoEstoqueMaterial (RecolhimentoEstoqueMaterial recolhimentoEstoqueMaterial);  
        void RegistrarRecolhimentoEstoqueMaterial(RecolhimentoEstoqueMaterial recolhimentoEstoqueMaterial); 
        void ExcluirRecolhimentoEstoqueMaterial(int id);
    }
}