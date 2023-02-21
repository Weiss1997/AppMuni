using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class SaludDiscapacitado
    {
        [Key]
        public int SaludDiscapacitadoID { get; set; }
        public string PreguntasSaludDiscapacitado { get; set; }
        public RespuestasSaludDiscapacitado RespuestasSaludDiscapacitado { get; set; }
        public string RespuestaCualSaludDiscapacitado { get; set; }
        public virtual ICollection<PersonaConDiscapacidad> PersonaConDiscapacidads { get; set; }

    }
    public enum RespuestasSaludDiscapacitado
    {
        Si = 1,
        No = 2
    }
    public class ListadoSaludDiscapacitado
    {
        public int SaludDiscapacitadoID { get; set; }
        public string PreguntasSaludDiscapacitado { get; set; }
        public RespuestasSaludDiscapacitado RespuestasSaludDiscapacitado { get; set; }
        public string RespuestaCualSaludDiscapacitado { get; set; }
    }
}