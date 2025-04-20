using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ListarCliente();   
        Cliente ObterClientePorId(int id);  
        void RegistrarCliente(Cliente cliente); 
        void AtualizarCliente(Cliente cliente);
        void ExcluirCliente(int id);
        

    }
}