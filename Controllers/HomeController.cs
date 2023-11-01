using Microsoft.AspNetCore.Mvc;
using MVC_ProyectoFinal.API_Service;
using MVC_ProyectoFinal.Areas.Flights.Models.Passengers;
using MVC_ProyectoFinal.Models;
using System.Diagnostics;

namespace MVC_ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Reservas()
        {
            List<Passenger>? passengers = await API_Service<Passenger>.Instance().Get();
            if (passengers == null) { return View(); }
            return View(passengers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}