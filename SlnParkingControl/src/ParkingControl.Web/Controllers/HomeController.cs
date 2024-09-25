using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Service.IServices;
using ParkingControl.Domain.DTOs;

namespace ParkingControl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVeiculoService _veiculoService;

        public HomeController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _veiculoService.BuscarTodos();

            foreach (var item in result)
            {
                if (item.dataHoraSaida.HasValue)
                {
                    item.duracao = _veiculoService.RetornarDuracao(item.dataHoraEntrada, item.dataHoraSaida.Value);
                    item.tempoCobrado = _veiculoService.CalcularTempoCobradoEmHoras(item.dataHoraEntrada, item.dataHoraSaida.Value);
                    item.valorPagar = _veiculoService.CalcularValorPagar(item.dataHoraEntrada, item.dataHoraSaida.Value, item.tarifa);
                }
            }

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id,placa,dataHoraEntrada")] VeiculoDTO veiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (veiculo.dataHoraEntrada > veiculo.dataHoraSaida)
                    {
                        throw new InvalidDataException("Data início não pode ser maior que a data fim.");
                    }

                    if (await _veiculoService.Salvar(veiculo) > 0) return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _veiculoService.BuscarPeloId(id);
                return View(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,placa,dataHoraEntrada,dataHoraSaida")] VeiculoDTO veiculo)
        {
            try
            {
                if (id != veiculo.id) return NoContent();

                if (ModelState.IsValid)
                {
                    if (await _veiculoService.Editar(veiculo) > 0)
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return View(veiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string placa)
        {
            try
            {
                var result = await _veiculoService.BuscarPorPlaca(placa);
                foreach (var item in result)
                {
                    if (item.dataHoraSaida.HasValue)
                    {
                        item.duracao = _veiculoService.RetornarDuracao(item.dataHoraEntrada, item.dataHoraSaida.Value);
                        item.tempoCobrado = _veiculoService.CalcularTempoCobradoEmHoras(item.dataHoraEntrada, item.dataHoraSaida.Value);
                        item.valorPagar = _veiculoService.CalcularValorPagar(item.dataHoraEntrada, item.dataHoraSaida.Value, item.tarifa);
                    }
                }

                return View(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}