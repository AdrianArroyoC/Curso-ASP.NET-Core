using System;
using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;

namespace HolaMundoMVC.Views.EscuelaController
{
    public class EscuelaController :  Controller
    {
        public IActionResult Index() 
        {
            var escuela = new Escuela();
            escuela.AñoFundación = 2005;
            escuela.EscuelaId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi";

            ViewBag.CosaDinamica = "La Monja";

            return View(escuela);
        }
    }
}