using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IPremiacaoRepository
    {
        IEnumerable<Premiacao> ListarPremiacao();  
        Premiacao ObterPremiacaoPorId(int id);  
        void RegistrarPremiacao(Premiacao premiacao); 
        void AtualizarPremiacao(Premiacao premiacao);
        void ExcluirPremiacao(int id);
    }
}