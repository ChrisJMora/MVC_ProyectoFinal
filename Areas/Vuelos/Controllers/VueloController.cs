﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_ProyectoFinal.Areas.Vuelos.Models;
using MVC_ProyectoFinal.Areas.Vuelos.Models.Pasajeros;
using MVC_ProyectoFinal.Areas.Vuelos.Utils;

namespace MVC_ProyectoFinal.Areas.Vuelos.Controllers
{
    [Area("Vuelos")]
    public class VueloController : Controller
    {
        Solicitud? _solicitud = BDsolicitud.Instancia().Solicitud;
        List<Vuelo>? _vuelos = ListaVuelos.Instancia().Vuelos;

        // GET: VueloController
        public IActionResult Index()
        {
            List<Vuelo>? vuelosDisponibles = 
                ListaVuelos.Instancia().vuelosDisponibles(_solicitud);

            Console.WriteLine($"Vuelos Disponibles: {vuelosDisponibles?.Count}");
            return View(vuelosDisponibles);
        }

        public IActionResult FormPasajero()
        {
            Pasajero? pasajero = _solicitud?.siguiente();
            return View(pasajero);
        }

        [HttpPost]
        public IActionResult FormPasajero(int Id, string Nombre, string Apellido,
            DateOnly fNacimiento, bool Genero)
        {
            Console.WriteLine($"Indice: {Id}");
            Console.WriteLine($"Nombre: {Nombre}, Apellido {Apellido}");
            Console.WriteLine($"Fecha de Nacimiento: {fNacimiento}, Genero: {Genero}");
            return RedirectToAction("FormPasajero");
        }

        public IActionResult Costo(int IdVuelo, bool Clase)
        {
            if (_vuelos == null) { return View(new Vuelo()); }

            Vuelo? vuelo = _vuelos.Find(x => x.Id == IdVuelo);

            if (vuelo == null) { return View( new Vuelo()); }

            vuelo.Clase = Clase;
            return View(vuelo);
        }



        // GET: VueloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VueloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VueloController/Create
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

        // GET: VueloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VueloController/Edit/5
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

        // GET: VueloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VueloController/Delete/5
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
