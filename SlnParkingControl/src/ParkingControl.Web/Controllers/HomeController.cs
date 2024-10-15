using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Service.IServices;
using ParkingControl.Domain.DTOs;
using ParkingControl.Domain.Enums;

namespace ParkingControl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVeiculoService _veiculoService;
        private readonly ITarifaService _tarifaService;

        public HomeController(IVeiculoService veiculoService, ITarifaService tarifaService)
        {
            _veiculoService = veiculoService;
            _tarifaService = tarifaService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _veiculoService.BuscarTodos();
            var tarifas = await _tarifaService.BuscarTodas();

            foreach (var item in result)
            {
                var tarifa = tarifas
                    .Where(t => t.dataInicioVigencia.Year == item.dataHoraEntrada.Year)
                    .Select(t => t.preco)
                    .FirstOrDefault();

                if (tarifa <= 0)
                {
                    item.Mensagem = $"Não há tarifa cadastrada para o período {item.dataHoraEntrada.Year}.";
                    item.ClasseTipoAlerta = item.RetornarTipoAlerta(TipoAlerta.Warning);
                }
                item.tarifa = tarifa;

                if (item.dataHoraSaida.HasValue)
                {
                    item.duracao = _veiculoService.RetornarDuracao(item.dataHoraEntrada, item.dataHoraSaida.Value);
                    item.tempoCobrado = _veiculoService.CalcularTempoCobradoEmHoras(item.dataHoraEntrada, item.dataHoraSaida.Value);
                    item.valorPagar = _veiculoService.CalcularValorPagar(item.dataHoraEntrada, item.dataHoraSaida.Value, tarifa);
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
                        veiculo.Mensagem = "Data início não pode ser maior que a data fim.";
                        return View(veiculo);
                    }

                    if (await _veiculoService.Salvar(veiculo) > 0)
                        return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                veiculo.Mensagem = ex.Message;
                veiculo.ClasseTipoAlerta = veiculo.RetornarTipoAlerta(TipoAlerta.Danger);
                return View(veiculo);
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
                var veiculo = new VeiculoDTO();
                veiculo.Mensagem = e.Message;
                veiculo.ClasseTipoAlerta = veiculo.RetornarTipoAlerta(TipoAlerta.Danger);

                return View(veiculo);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,placa,dataHoraEntrada,dataHoraSaida")] VeiculoDTO veiculo)
        {
            try
            {
                if (id != veiculo.id)
                {
                    veiculo.Mensagem = "Ocorreu um erro ao buscar o registro no banco de dados.";
                    veiculo.ClasseTipoAlerta = veiculo.RetornarTipoAlerta(TipoAlerta.Warning);
                    return View(veiculo);
                }

                if (await _veiculoService.Editar(veiculo) > 0)
                    return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                veiculo.Mensagem = e.Message;
                veiculo.ClasseTipoAlerta = veiculo.RetornarTipoAlerta(TipoAlerta.Danger);
                return View(veiculo);
            }

            return View(veiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string placa)
        {
            try
            {
                var tarifas = await _tarifaService.BuscarTodas();
                var result = await _veiculoService.BuscarPorPlaca(placa);

                foreach (var item in result)
                {
                    var tarifa = tarifas
                    .Where(t => t.dataInicioVigencia.Year == item.dataHoraEntrada.Year)
                    .Select(t => t.preco)
                    .FirstOrDefault();

                    if (tarifa <= 0)
                    {
                        item.Mensagem = "Não há tarifa cadastrada para o período!";
                        item.ClasseTipoAlerta = item.RetornarTipoAlerta(TipoAlerta.Warning);
                    }
                    item.tarifa = tarifa;

                    if (item.dataHoraSaida.HasValue)
                    {
                        item.duracao = _veiculoService.RetornarDuracao(item.dataHoraEntrada, item.dataHoraSaida.Value);
                        item.tempoCobrado = _veiculoService.CalcularTempoCobradoEmHoras(item.dataHoraEntrada, item.dataHoraSaida.Value);
                        item.valorPagar = _veiculoService.CalcularValorPagar(item.dataHoraEntrada, item.dataHoraSaida.Value, tarifa);
                    }
                }

                return View(result);
            }
            catch (Exception e)
            {
                var veiculo = new VeiculoDTO();
                veiculo.Mensagem = e.Message;
                veiculo.ClasseTipoAlerta = veiculo.RetornarTipoAlerta(TipoAlerta.Danger);
                return View(veiculo);
            }
        }
    }
}