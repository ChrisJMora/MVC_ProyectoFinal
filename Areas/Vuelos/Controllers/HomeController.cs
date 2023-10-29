using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using MVC_ProyectoFinal.Areas.Vuelos.Models;
using MVC_ProyectoFinal.Areas.Vuelos.Utils;

namespace MVC_ProyectoFinal.Areas.Vuelos.Controllers
{
    [Area("Vuelos")]
    public class HomeController : Controller
    {
        List<Ciudad>? ciudades = ListaCiudades.Instancia().Ciudades;
        Solicitud solicitud = BDsolicitud.Instancia().Solicitud;

        // GET: IndexController
        public IActionResult Index()
        {
            return View(ciudades);
        }

        [HttpPost]
        public IActionResult Index(int Origen, int Destino, DateOnly fSalida,
            int Adultos, int Ninios, int Infantes)
        {
            Console.WriteLine("SOLICITUD:");
            Console.WriteLine($"Origen: {Origen} -> Destino: {Destino}");
            Console.WriteLine($"Fecha de Salida: {fSalida}");
            Console.WriteLine("Acompañantes:");
            Console.WriteLine($"Adultos: {Adultos}, Niños: {Ninios}," +
                $"Infantes: {Infantes}");

            Solicitud solicitud = new Solicitud();
            if (solicitud.verificarViaje(Origen, Destino))
            {
                Console.WriteLine("Formato Incorrecto!");
                return View();
            }

            solicitud.Origen = Origen;
            solicitud.Destino = Destino;
            solicitud.FSalida = fSalida;
            solicitud.initAcompaniantes(Adultos, Ninios, Infantes);

            if(this.solicitud != null)
            {
                BDsolicitud.Instancia().Solicitud = solicitud;
            }

            return RedirectToAction("Index","Vuelo");
        }





        // GET: IndexController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndexController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndexController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndexController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndexController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndexController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndexController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
