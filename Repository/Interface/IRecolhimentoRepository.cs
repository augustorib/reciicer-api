using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IRecolhimentoRepository
    {     
        IEnumerable<Recolhimento> ListarRecolhimento();   
        Recolhimento ObterRecolhimentoPorId(int id);  
        void RegistrarRecolhimento(Recolhimento recolhimento); 
        void AtualizarRecolhimento(Recolhimento recolhimento);
        void ExcluirRecolhimento(int id);
    }
}