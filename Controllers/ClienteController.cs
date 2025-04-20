using Microsoft.AspNetCore.Mvc;
using Reciicer.Models.Entities;
using Reciicer.Service.Cliente;
using ReciicerAPI.Models.DTOs.Cliente;
using ReciicerAPI.Models.DTOs.Coleta;

namespace Reciicer.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService; 

        public ClienteController(ClienteService clienteService)
        {
            
            _clienteService = clienteService;
 
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            var clientes = _clienteService.ListarCliente();

            var clientesDTO = new List<ClienteReadDTO>();
            
            foreach (var cliente in clientes)
            {
                var clienteDTO = new ClienteReadDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone,
                    CPF = cliente.CPF
                };

                clientesDTO.Add(clienteDTO);
            }

            return Ok(clientesDTO);
        }


        [HttpPost]
        public IActionResult Create([FromBody] ClienteCreateDTO clienteCreateDTO)
        {

            var cliente = new Cliente
            {
                Nome = clienteCreateDTO.Nome,
                Email = clienteCreateDTO.Email,
                Telefone = clienteCreateDTO.Telefone,
                CPF = clienteCreateDTO.CPF
            };

            _clienteService.RegistrarCliente(cliente);

            return Created($"/api/clientes/{cliente.Id}", cliente);
         }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {  
            var cliente = _clienteService.ObterClientePorId(id);

            if (cliente == null)
            {
                return NotFound($"Cliente com ID {id} não encontrado.");
            }

            var clienteDTO = new ClienteReadDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                CPF = cliente.CPF
            };

            return Ok(clienteDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ClienteUpdateDTO cliente)
        {

            var clienteBD = _clienteService.ObterClientePorId(id);

            clienteBD.Nome = cliente.Nome;
            clienteBD.Email = cliente.Email;
            clienteBD.Telefone = cliente.Telefone;
            clienteBD.CPF = cliente.CPF;

            _clienteService.AtualizarCliente(clienteBD);
          
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clienteService.ExcluirCliente(id);

            return NoContent();
        }

        [HttpGet("{id}/coletas")]
        public IActionResult ClienteColetas(int id)
        {
            var cliente = _clienteService.ObterClientePorId(id);
            
            var coletas = cliente.Coletas!.Select(c => new ColetaBaseDTO
            {
                Id = c.Id,
                DataOperacao = c.DataOperacao,
                PontuacaoGanha = c.PontuacaoGanha,

            }).ToList();

            var clienteResponse = new ClienteColetasDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                CPF = cliente.CPF,
                Coletas = coletas
            };

            return Ok(clienteResponse);
        }

        // [HttpGet]
        // public IActionResult ClientePremiacao(int? premiacaoId )
        // {     
        //     return View(_premiacaoService.MontarViewModelPremiarCliente(premiacaoId));
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public IActionResult NotificarClientePremiacao(string email, int premiacaoId)
        // { 
            
        //     var emailEnviado =  _emailService.EnviarEmail("guhstudante@gmail.com", "Premiação Disponível",_emailService.MontarEmailBody());

        //     if(emailEnviado)
        //     {
        //        TempData["Mensagem"] = $"Email para {email} enviado!";
        //     }
        //     else
        //     {
        //         TempData["Mensagem"] = $"Falha ao enviar o email para {email}.";
        //     }

        //     return RedirectToAction("ClientePremiacao", new {premiacaoId});
        // }

    }

}