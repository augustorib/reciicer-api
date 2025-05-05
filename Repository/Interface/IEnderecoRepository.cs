using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IEnderecoRepository
    {
        IEnumerable<Endereco> ListarEndereco();  
        Endereco ObterEnderecoPorId(int id);  
        void RegistrarEndereco(Endereco endereco); 
        void AtualizarEndereco(Endereco endereco);
        void ExcluirEndereco(int id);
    }
}