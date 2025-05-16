using ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Repository.Interface
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ListarCliente();   
        Task<Cliente> ObterClientePorId(int id);  
        Task RegistrarCliente(Cliente cliente); 
        Task AtualizarCliente(Cliente cliente);
        Task ExcluirCliente(int id);
        

    }
}