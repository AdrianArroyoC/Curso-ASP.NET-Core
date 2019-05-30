using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolaMundoMVC.Views.EscuelaController
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;

        [Route("Asignatura")]
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]//El enrutamiento por atributos rompe la convención
        public IActionResult Index(string asignaturaId) //Funcionaría si se llama solo id como lo indica la convención 
        {
            if(!string.IsNullOrWhiteSpace(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas where asig.Id == asignaturaId select asig;
                return View(asignatura.SingleOrDefault());
            }
            else
            {
                return  View("MultiAsignatura", _context.Asignaturas);
            }
        }
        
        public IActionResult MultiAsignatura()
        {
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAsignatura", _context.Asignaturas);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now; 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            ViewBag.Fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                var cursos = (from curs in _context.Cursos select curs).ToList();
                var lista = new List<SelectListItem>();
                foreach (Curso curs in cursos)
                {
                    lista.Add(new SelectListItem { Text = curs.Nombre, Value = curs.Id });
                }
                ViewBag.Cursos = lista;
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Asignatura creado";
                return View("Index", asignatura);
            }
            return View(asignatura);
        }

        public IActionResult Update(string id)
        {   
            if(!string.IsNullOrWhiteSpace(id))
            {
                var asignatura = from asig in _context.Asignaturas where asig.Id == id select asig;
                var cursos = (from curs in _context.Cursos select curs).ToList();
                var lista = new List<SelectListItem>();
                foreach (Curso curs in cursos)
                {
                    lista.Add(new SelectListItem { Text = curs.Nombre, Value = curs.Id });
                }
                ViewBag.Cursos = lista;
                ViewBag.Fecha = DateTime.Now;             
                return View(asignatura.SingleOrDefault());
            }
            return  View("MultiAsignatura", _context.Asignaturas);
        }

        [HttpPost]
        public IActionResult Update(string id, Asignatura asignatura)
        {
            ViewBag.Fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                var tmpAsignatura = from asig in _context.Asignaturas where asig.Id == id select asig;
                _context.Asignaturas.Remove(tmpAsignatura.FirstOrDefault());
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Asignatura editado";
                return View("Index", asignatura);
            }
            return View(asignatura);
        }

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}