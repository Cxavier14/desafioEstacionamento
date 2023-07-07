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

        public IActionResult Index()
        {
            var result = _veiculoService.BuscarTodos();
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

        public async Task<IActionResult> Details(int id)
        {
            var result = await _veiculoService.BuscarPeloId(id);
            return View(result);
        }
    }
}