using Microsoft.EntityFrameworkCore;
using ReciicerAPI.Data;
using ReciicerAPI.Models.Entities;
using ReciicerAPI.Repository.Interface;



namespace ReciicerAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            var clientes = _context.Cliente.ToList();

            return clientes;
        }     

        public Cliente ObterClientePorId(int id)
        {
            return _context.Cliente.Include(c => c.Coletas).FirstOrDefault(c => c.Id == id)!;
        }

        public void RegistrarCliente(Cliente model)
        {
           
            _context.Cliente.Add(model);
            _context.SaveChanges();
        }

        public Cliente DetalharCliente(int id)
        {
           
            var clienteBD = _context.Cliente.Find(id);
                
            if(clienteBD is not null)
            {
                return clienteBD;
            }

            return new Cliente();

        }

        public void AtualizarCliente(Cliente cliente)
        {
            var clienteBD = _context.Cliente.Find(cliente.Id);


            if (clienteBD != null)
            {
                // testar implementação de  performance 
                //clienteBd.id = cliente.Id;
                clienteBD.Nome = cliente.Nome;
                clienteBD.Telefone = cliente.Telefone;
                clienteBD.CPF = cliente.CPF;
                clienteBD.Email = cliente.Email;
                clienteBD.CNPJ = cliente.CNPJ;


                _context.Cliente.Update(clienteBD);
                _context.SaveChanges();

            }

        }

        public void ExcluirCliente(int id)
        {
            var cliente = new Cliente { Id = id };
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
        }

    }
}