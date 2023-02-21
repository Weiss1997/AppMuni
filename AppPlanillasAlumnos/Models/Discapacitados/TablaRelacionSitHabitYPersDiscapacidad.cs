using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class TablaRelacionSitHabitYPersDiscapacidad
    {
        [Key]
        public int TablaRelacionSitHabitYPersDiscapacidadID { get; set; }
        public int PersonaConDiscapacidadID { get; set; }
        public int SituacionHabitacionalID { get; set; }
        public string Observacion { get; set; } 
        public virtual PersonaConDiscapacidad PersonaConDiscapacidad { get; set; }
        public virtual SituacionHabitacional SituacionHabitacional { get; set; }
    }
}