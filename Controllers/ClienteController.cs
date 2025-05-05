using Microsoft.AspNetCore.Mvc;
using ReciicerAPI.Service.Cliente;
using ReciicerAPI.Models.DTOs.Cliente;
using ReciicerAPI.Extensions;

namespace ReciicerAPI.Controllers
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

            var clientesDTO = clientes.Select(c => c.ToClienteReadDTO()).ToList();

            return Ok(clientesDTO);
        }


        [HttpPost]
        public IActionResult Create([FromBody] ClienteCreateDTO clienteCreateDTO)
        {

            var cliente = clienteCreateDTO.ToCliente();

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

            var clienteDTO = cliente.ToClienteReadDTO();

            return Ok(clienteDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ClienteUpdateDTO clienteUpdateDTO)
        {
            var cliente = clienteUpdateDTO.ToCliente(id);
            
            try
            {
                _clienteService.AtualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar cliente: {id} Detalhes: {ex.Message}");
            }
          
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
            
            var coletas = cliente.Coletas?.Select(c => c.ToColetaBaseDTO()).ToList();

            var clienteResponse = cliente.ToClienteColetasDTO(coletas!);

            return Ok(clienteResponse);
        }

    }

}