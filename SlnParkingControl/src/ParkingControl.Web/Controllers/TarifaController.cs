using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Service.IServices;
using ParkingControl.Domain.DTOs;

namespace ParkingControl.Web.Controllers
{
    public class TarifaController : Controller
    {
        private readonly ITarifaService _tarifaService;

        public TarifaController(ITarifaService tarifaService)
        {
            _tarifaService = tarifaService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _tarifaService.BuscarTodas();
                return View(result);
            }
            catch (Exception ex)
            {
                var result = new TarifaDTO()
                {
                    Mensagem = ex.Message
                };

                return View(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id,placa,dataHoraEntrada")] TarifaDTO tarifaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (tarifaDTO.dataInicioVigencia > tarifaDTO.dataFimVigencia)
                    {
                        tarifaDTO.Mensagem = "Data início não pode ser maior que a data fim.";
                        return View(tarifaDTO);
                    }

                    if (await _tarifaService.Salvar(tarifaDTO) > 0) 
                        return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var result = new TarifaDTO()
                {
                    Mensagem = ex.Message
                };

                return View(result);
            }
        }
    }
}
