using System.Globalization;
using Reciicer.Models.HomeViewModels;
using Reciicer.Repository.Interface;
using Reciicer.Service.UsuarioIdentity;
using  Entities = Reciicer.Models.Entities;


namespace Reciicer.Service.Cliente
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

        public IEnumerable<Entities.Cliente> ListarCliente()
        {
           return _clienteRepository.ListarCliente();
        }

        public IEnumerable<Entities.Cliente> ListarCliente(int pontoColetaId)
        {
           var usuariosPontoColeta = _usuarioIdentityService.ObterUsuariosPorPontoColetaId(pontoColetaId);  

           return _clienteRepository.ListarCliente().Where(c => usuariosPontoColeta.Any(u => u.Id == c.CreatedBy)).ToList();
        }
        
        public void RegistrarCliente(Entities.Cliente cliente)
        {
            _clienteRepository.RegistrarCliente(cliente);
        }

        public Entities.Cliente ObterClientePorId(int id)
        {
           return _clienteRepository.ObterClientePorId(id);
        }

        public void AtualizarCliente(Entities.Cliente cliente)
        {
            _clienteRepository.AtualizarCliente(cliente);
        }

        public void ExcluirCliente(int id)
        {
            _clienteRepository.ExcluirCliente(id);
        }
        
        public IEnumerable<Entities.Cliente> ObterClientesOrdenadoPorPontuação()
        {
            var  clientesTop10 = _clienteRepository.ListarCliente()
                                                  .OrderByDescending(c => c.PontuacaoTotal)
                                                  .Take(10)
                                                  .ToList();
            return clientesTop10;
        }

        public IEnumerable<Entities.Cliente> ObterClientesOrdenadoPorPontuação(int pontoColetaId)
        {
            var usuariosPontoColeta = _usuarioIdentityService.ObterUsuariosPorPontoColetaId(pontoColetaId);
            var  clientesTop10 = _clienteRepository.ListarCliente()
                                                   .Where(c => usuariosPontoColeta.Any(u => u.Id == c.CreatedBy))      
                                                   .OrderByDescending(c => c.PontuacaoTotal)
                                                   .Take(10)
                                                   .ToList();
            return clientesTop10;
        }
        
         public int ObterTotalClientes(int anoDashboard)
         {
            return _clienteRepository.ListarCliente().Where(c => c.DataCadastro.Year == anoDashboard).Count();
         }

         public int ObterTotalClientes(int anoDashboard, int pontoColetaId)
         {
            var usuariosPontoColeta = _usuarioIdentityService.ObterUsuariosPorPontoColetaId(pontoColetaId);

            return _clienteRepository.ListarCliente()
                                     .Where(c => c.DataCadastro.Year == anoDashboard &&
                                            usuariosPontoColeta.Any(u => u.Id == c.CreatedBy))
                                     .Count();
         }

         
         public IEnumerable<ClientePorMes> ObterTotalClientesPorMes(int? anoFiltroDashBoard, int pontoColetaId)
         {

            var usuariosPontoColeta = _usuarioIdentityService.ObterUsuariosPorPontoColetaId(pontoColetaId);

            var query = _clienteRepository.ListarCliente().AsQueryable();

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

         public Entities.Cliente clienteColetas(int id)
         {
            return _clienteRepository.ObterClientePorId(id);
         }

    }
}