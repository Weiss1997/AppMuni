using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class Tratamiento
    {
        [Key]
        public int TratamientoID { get; set; }

        [Display(Name = "Anteriores:")]
        public string TratamientoAnterior { get; set; }

        [Display(Name = "Actuales:")]
        [Required]
        public string TratamientoActuales { get; set; }       

        public int ProfesionalID { get; set; }

        public int PacienteID { get; set; }

        public bool Eliminado { get; set; }

        public virtual Paciente Paciente { get; set; }
    }

    public class ListadoTratamientos
    {
        public string TratamientoAnterior { get; set; }
        public string TratamientoActuales { get; set; }

        public int TratamientoID { get; set; }

        public int PacienteID { get; set; }
        public string PacienteNombre { get; set; }

        public int ProfesionalID { get; set; }
        public string ProfesionalNombre { get; set; }
    }
}