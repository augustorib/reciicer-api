using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReciicerAPI.Models;
using ReciicerAPI.Models.HomeViewModels;
using ReciicerAPI.Service.Cliente;
using ReciicerAPI.Service.Coleta;
using ReciicerAPI.Service.TipoMaterial;


namespace ReciicerAPI.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ClienteService _clienteService;
    private readonly ColetaService _coletaService;
    private readonly TipoMaterialService _tipoMaterialService;

    public HomeController(ClienteService clienteService, ColetaService coletaService, TipoMaterialService tipoMaterialService)
    {
        _clienteService = clienteService;
        _coletaService  = coletaService;
        _tipoMaterialService  = tipoMaterialService;

    }


    public async Task<IActionResult> Index(int? anoDashboard)
    {
        var anoSelectDashboard = anoDashboard ?? DateTime.Now.Year;

        var pontoColetaId = Convert.ToInt32(User.FindFirst("PontoColetaId")?.Value);
        
        var model = new HomeIndexViewModel{
            TotalCliente = await _clienteService.ObterTotalClientes(anoSelectDashboard, pontoColetaId),
            TotalColeta = _coletaService.ObterTotalColeta(anoSelectDashboard, pontoColetaId),
            DataUltimaColeta = _coletaService.ObterDataUltimaColeta(pontoColetaId).ToString("dd/MM/yyyy HH:mm"),
            TipoMaterialQuantidadeCharts =  _tipoMaterialService.ObterNomeQuantidadeTipoMaterialGrafico(anoSelectDashboard, pontoColetaId),
            Top10Clientes = await  _clienteService.ObterClientesOrdenadoPorPontuação(pontoColetaId),
            ClientePorMes = await _clienteService.ObterTotalClientesPorMes(anoSelectDashboard, pontoColetaId),
            ColetasPorMes = _coletaService.ObterTotalColetasPorMes(anoSelectDashboard, pontoColetaId),
            AnoSelecionado = anoSelectDashboard 
        };
     
        return View(model);
    }

    [AllowAnonymous]
    public IActionResult Privacy()
    {    
        return View();
    }

}
