using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class SituacionLaboral
    {
        [Key]
        public int SituacionLaboralID { get; set; }
        public string SituacionLaboralDescripcion { get; set; }
        public string SituacionConsultante { get; set; }
        public string SituacionDiscapacitado { get; set; }
        public decimal IngresosDeTrabajo { get; set; }

    }
    public class ListadoSituacionLaboral
    {
        public int SituacionLaboralID { get; set; }
        public string SituacionLaboralDescripcion { get; set; }
        public string SituacionConsultante { get; set; }
        public string SituacionDiscapacitado { get; set; }
        public decimal IngresosDeTrabajo { get; set; }
    }
}