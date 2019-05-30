using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
using System.Collections.Generic;

namespace HolaMundoMVC.Views.EscuelaController
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;

        [Route("Curso")]
        [Route("Curso/Index")]
        [Route("Curso/Index/{Id}")]
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                var curso = from curs in _context.Cursos where curs.Id == id select curs;
                return View(curso.SingleOrDefault());
            }
            else
            {
                return  View("MultiCurso", _context.Cursos);
            }
        }
        public IActionResult MultiCurso()
        {
            ViewBag.Fecha = DateTime.Now;
            return View("MultiCurso", _context.Cursos);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now; 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Curso creado";
                return View("Index", curso);
            }
            return View(curso);
        }

        
        public IActionResult Update(string id)
        {   
            if(!string.IsNullOrWhiteSpace(id))
            {
                var curso = from curs in _context.Cursos where curs.Id == id select curs;
                ViewBag.Fecha = DateTime.Now;             
                return View(curso.SingleOrDefault());
            }
            return  View("MultiCurso", _context.Cursos);
        }

        [HttpPost]
        public IActionResult Update(string id, Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                var tmpCurso = from curs in _context.Cursos where curs.Id == id select curs;
                _context.Cursos.Remove(tmpCurso.FirstOrDefault());
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Curso editado";
                return View("Index", curso);
            }
            return View(curso);
        }

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}