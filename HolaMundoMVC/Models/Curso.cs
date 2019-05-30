using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HolaMundoMVC.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "El nombre del curso es requerido")]
        [StringLength(6)]
        public override string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas{ get; set; }

        public List<Alumno> Alumnos{ get; set; }

        [Display(Prompt = "Dirección correspondencia", Name = "Adress")]
        [Required(ErrorMessage = "La dirección es requerida")]
        [MinLength(10, ErrorMessage = "La longitud mínima es 10")]
        public string Dirección { get; set; }

        public string EscuelaId { get; set; }

        public Escuela Escuela { get; set; }

        public Curso()
        {
            
        }
    }
}