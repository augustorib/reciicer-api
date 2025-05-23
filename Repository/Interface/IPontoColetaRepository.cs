using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IPontoColetaRepository
    {
        IEnumerable<PontoColeta> ListarPontoColeta();  
        PontoColeta ObterPontoColetaPorId(int id);  
        void RegistrarPontoColeta(PontoColeta pontoColeta); 
        void AtualizarPontoColeta(PontoColeta pontoColeta);
        void ExcluirPontoColeta(int id);
    }
}