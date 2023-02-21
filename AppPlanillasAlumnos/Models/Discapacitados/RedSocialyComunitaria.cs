using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class RedSocialyComunitaria
    {
        [Key]
        public int RedSocialyComunitariaID { get; set; }
        public string PreguntasRedes { get; set; }
        public RespuestasRedes respuestasRedes { get; set; }
        public string RespuestaEscrita { get; set; }
        public virtual ICollection<PersonaConDiscapacidad> PersonaConDiscapacidads { get; set; }

    }
    public enum RespuestasRedes
    {
        Si = 1,
        No = 2
    }
    public class ListadoRedSocialyComunitaria
    {
        public int RedSocialyComunitariaID { get; set; }
        public string PreguntasRedes { get; set; }
        public RespuestasRedes respuestasRedes { get; set; }
        public string RespuestaEscrita { get; set; }
    }
}