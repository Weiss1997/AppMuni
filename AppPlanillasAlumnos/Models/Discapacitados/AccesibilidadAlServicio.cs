using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class AccesibilidadAlServicio
    {
        [Key]
        public int AccesibilidadAlServicioID { get; set; }
        public string AccesibilidadDescripcion { get; set; }
        public virtual ICollection<PersonaConDiscapacidad> PersonaConDiscapacidads { get; set; }

    }
    public class ListadoAccesibilidadAlServicio
    {
        public int AccesibilidadAlServicioID { get; set; }
        public string AccesibilidadDescripcion { get; set; }

    }
}