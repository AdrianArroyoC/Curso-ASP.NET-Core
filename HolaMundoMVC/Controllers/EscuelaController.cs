using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;

namespace HolaMundoMVC.Views.EscuelaController
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;

        public IActionResult Index()
        {
            ViewBag.CosaDinamica = "Cosa Dinámica";
            var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela);
        }

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}