using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class DatosDeAdmision
    {

        [Key]
        public int FichaAdmisionID { get; set; }



        [Required(ErrorMessage = "Debe ingresar una fecha")]
        [Display(Name = "Fecha: ")]
        public DateTime FichaAdmisionFecha { get; set; }

        [Display(Name = "Persona que proporciona la informacion (parentesco): ")]
        public string FichaAdmisionParentesco { get; set; }

        [Display(Name = "Descripcion de la problemática o dificultad del niño: ")]
        public string FichaAdmisionDescripcion { get; set; }

        [Display(Name = "Servicio solicitado: ")]
        public string FichaAdmisionServicio { get; set; }

        [Display(Name = "Relación con los demás (padres, hermanos, amigos, etc.) ")]
        public string FichaAdmisionRelacion { get; set; }

        [Display(Name = "Observaciones: ")]
        public string FichaAdmisionObservacion { get; set; }

        public int ProfesionalID { get; set; }
     
        public int PacienteID { get; set; }

        public bool Eliminado { get; set; }

        public virtual Paciente Paciente { get; set; }

    }
    public class ListadoDatosAdmision 
    {
        public int FichaAdmisionID { get; set; }
        public string FichaAdmisionFechaString { get; set; }
        public string FichaAdmisionParentesco { get; set; }
        public string FichaAdmisionDescripcion { get; set; }
        public string FichaAdmisionServicio { get; set; }
        public string FichaAdmisionRelacion { get; set; }
        public string FichaAdmisionObservacion { get; set; }

        public ListadoProfesionales Profesionales { get; set; }
        public int PacienteID { get; set; }
        public string PacienteNombre { get; set; }
    }
}