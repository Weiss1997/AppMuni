using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class Especializacion
    {


        [Key]
        public int EspecializacionID { get; set; }

        [Display(Name = "Nombre de la especializacion:")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [StringLength(200, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string EspecializacionNombre { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<Profesional> Profesionals { get; set; }
    }
    public class ListadoEspecializaciones {
        public int EspecializacionID { get; set; }
        public string EspecializacionNombre { get; set; }
    }

}