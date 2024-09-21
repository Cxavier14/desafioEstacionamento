using Microsoft.AspNetCore.Mvc;

namespace ParkingControl.Web.Controllers
{
    public class TarifaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
