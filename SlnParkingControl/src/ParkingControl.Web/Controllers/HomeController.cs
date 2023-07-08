using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Service.IServices;
using ParkingControl.Domain.DTOs;
using ParkingControl.Web.Models;
using System.Diagnostics;

namespace ParkingControl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVeiculoService _veiculoService;

        public HomeController(IVeiculoService veiculoService)
        {
            _veiculoService= veiculoService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _veiculoService.BuscarTodos();

            foreach (var item in result)
            {
                item.duracao = _veiculoService.CalculaDuracao(item.dataHoraEntrada, item.dataHoraSaida);
                item.tempoCobrado = _veiculoService.CalculaTempoCobradoEmHoras(item.dataHoraEntrada, item.dataHoraSaida);
                item.valorPagar = _veiculoService.CalculaValorPagar(item.dataHoraEntrada, item.dataHoraSaida, item.tarifa);
            }

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VeiculoDTO veiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _veiculoService.Salvar(veiculo) > 0) RedirectToAction(nameof(Index));
                }
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _veiculoService.BuscarPeloId(id);
            return View(result);
        }
    }
}