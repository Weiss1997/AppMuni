using AppPlanillasAlumnos.Models.SeguimientoInfantil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class Profesional
    {

        [Key]
        public int ProfesionalID { get; set; }

        [Display(Name = "Matricula profesional:")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]

        public string ProfesionalMatricula { get; set; }
        public int PersonaID { get; set; }

        public virtual Persona Persona { get; set; }

        [NotMapped]
        public string PersonaApellidoNombre { get; set; }
        public bool Eliminado { get; set; }

        public int EspecializacionID { get; set; }

        public virtual Especializacion Especializacion { get; set; }

        public virtual ICollection<FormularioCPPP> FormulariosCPPP { get; set; }

    }
    public class ListadoProfesionales
    {
        public int ProfesionalID { get; set; }
        public string ProfesionalMatricula { get; set; }
        public string PersonaApellidoNombre { get; set; }
        public ListadoPersonas Persona { get; set; }
        public ListadoEspecializaciones Especializaciones { get; set; }
    }
}