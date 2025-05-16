using System.Globalization;
using ReciicerAPI.Models.HomeViewModels;
using ReciicerAPI.Repository.Interface;
using ReciicerAPI.Service.UsuarioIdentity;
using  Entities = ReciicerAPI.Models.Entities;


namespace ReciicerAPI.Service.Cliente
{
    public class ClienteService 
    {
        private readonly IClienteRepository _clienteRepository;

        private readonly UsuarioIdentityService _usuarioIdentityService;
    
        public ClienteService(IClienteRepository clienteRepository, UsuarioIdentityService usuarioIdentityService)
        {
            _clienteRepository = clienteRepository;
            _usuarioIdentityService = usuarioIdentityService;
    }

        public async Task<IEnumerable<Entities.Cliente>> ListarCliente()
        {
           return await _clienteRepository.ListarCliente();
        }

        public async Task<IEnumerable<Entities.Cliente>> ListarCliente(int pontoColetaId)
        {
           var usuariosPontoColeta = _usuarioIdentityService.ObterUsuariosPorPontoColetaId(pontoColetaId);

           var clientes = await _clienteRepository.ListarCliente();

           return clientes.Where(c => usuariosPontoColeta.Any(u => u.Id == c.CreatedBy)).ToList();
        }
        
        public async Task RegistrarCliente(Entities.Cliente cliente)
        {
            await _clienteRepository.RegistrarCliente(cliente);
        }

        public async Task<Entities.Cliente> ObterClientePorId(int id)
        {
           return await _clienteRepository.ObterClientePorId(id);
        }

        public void AtualizarCliente(Entities.Cliente cliente)
        {
            _clienteRepository.AtualizarCliente(cliente);
        }

        public void ExcluirCliente(int id)
        {
            _clienteRepository.ExcluirCliente(id);
        }
        
        public async Task<IEnumerable<Entities.Cliente>> ObterClientesOrdenadoPorPontuação()
        {
            var clientes = await _clienteRepository.ListarCliente();

            var clientesTop10 =  clientes.OrderByDescending(c => c.PontuacaoTotal)
                                            .Take(10)
                                            .ToList();
            return clientesTop10;
        }

        public async Task<IEnumerable<Entities.Cliente>> ObterClientesOrdenadoPorPontuação(int pontoColetaId)
        {
            var usuariosPontoColeta = _usuarioIdentityService.ObterUsuariosPorPontoColetaId(pontoColetaId);
            var clientesAsync = await _clienteRepository.ListarCliente();


            var clientes = clientesAsync.Where(c => usuariosPontoColeta.Any(u => u.Id == c.CreatedBy))      
                                        .OrderByDescending(c => c.PontuacaoTotal)
                                        .Take(10)
                                        .ToList();
            return clientes;
        }
        
         public async Task<int> ObterTotalClientes(int anoDashboard)
         {
            var clientesAsync = await _clienteRepository.ListarCliente();

            return clientesAsync.Where(c => c.DataCadastro.Year == anoDashboard).Count();
         }

         public async Task<int> ObterTotalClientes(int anoDashboard, int pontoColetaId)
         {
            var usuariosPontoColeta = _usuarioIdentityService.ObterUsuariosPorPontoColetaId(pontoColetaId);

            var clientesAsync = await _clienteRepository.ListarCliente();

            return clientesAsync.Where(c => c.DataCadastro.Year == anoDashboard &&
                                       usuariosPontoColeta.Any(u => u.Id == c.CreatedBy))
                                .Count();
         }

         
         public async Task<IEnumerable<ClientePorMes>> ObterTotalClientesPorMes(int? anoFiltroDashBoard, int pontoColetaId)
         {

            var usuariosPontoColeta = _usuarioIdentityService.ObterUsuariosPorPontoColetaId(pontoColetaId);

            var clientesAsync = await _clienteRepository.ListarCliente();
            
            var query = clientesAsync.AsQueryable();

            if (anoFiltroDashBoard.HasValue)
            {
                query = query.Where(c => c.DataCadastro.Year == anoFiltroDashBoard
                                    && usuariosPontoColeta.Any(u => u.Id == c.CreatedBy));
            }

            var clientesPorMes = query
                                    .GroupBy(c => new {c.DataCadastro.Month, c.DataCadastro.Year})
                                    .Select(c => new ClientePorMes
                                    {
                                        Mes = c.Key.Month,
                                        Ano = c.Key.Year,
                                        TotalCliente = c.Count(),
                                        NomeMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(c.Key.Month),
                                    })
                                    .OrderBy(g => g.Ano)
                                    .ThenBy(g => g.Mes)
                                    .ToList();
             return clientesPorMes;
         }

         public async Task<Entities.Cliente> clienteColetas(int id)
         {
            return await _clienteRepository.ObterClientePorId(id);
         }

    }
}