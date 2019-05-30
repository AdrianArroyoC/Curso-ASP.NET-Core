using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;

namespace HolaMundoMVC.Views.EscuelaController
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;

        [Route("Alumno")]
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{Id}")]
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                var alumno = from alum in _context.Alumnos where alum.Id == id select alum;
                return View(alumno.SingleOrDefault());
            }
            else
            {
                return  View("MultiAlumno", _context.Alumnos);
            }
        }
        public IActionResult MultiAlumno()
        {
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAlumno", _context.Alumnos);
        }

        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}