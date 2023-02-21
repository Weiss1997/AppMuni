using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class TipodeDiscapacidad
    {
        [Key]
        public int TipodeDiscapacidadID { get; set; }
        public string NombredelaDiscapacidad { get; set; }
        public virtual ICollection<PersonaConDiscapacidad> PersonaConDiscapacidads { get; set; }
    }
    public class ListadoTipodeDiscapacidad
    {
        public int TipodeDiscapacidadID { get; set; }
        public string NombredelaDiscapacidad { get; set; }
    }
}