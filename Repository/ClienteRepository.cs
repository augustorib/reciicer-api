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

        public async Task<IEnumerable<Cliente>> ListarCliente()
        {
            var clientes = await _context.Cliente.ToListAsync();

            return clientes;
        }     

        public async Task<Cliente> ObterClientePorId(int id)
        {
            var cliente = await _context.Cliente.Include(c => c.Coletas).FirstOrDefaultAsync(c => c.Id == id);

            return cliente!;
        }

        public async Task RegistrarCliente(Cliente model)
        {
            await _context.Cliente.AddAsync(model);
            await _context.SaveChangesAsync();
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

        public async Task AtualizarCliente(Cliente cliente)
        {
            var clienteBD = await _context.Cliente.FindAsync(cliente.Id);


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
                await _context.SaveChangesAsync();

            }

        }

        public async Task ExcluirCliente(int id)
        {
            var cliente = new Cliente { Id = id };
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
        }

    }
}