

using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IColetaRepository
    {
        IEnumerable<Coleta> ListarColeta();  
        Coleta ObterColetaPorId(int id);  
        void RegistrarColeta(Coleta Coleta); 
        void AtualizarColeta(Coleta Coleta);
        void ExcluirColeta(int id);
        Coleta ObterClienteUltimaColeta(int ClienteId);
        void CalcularPontuacaoColeta(int reciclagemId);
    }
}