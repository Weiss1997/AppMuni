using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class SaludConsultante
    {
        [Key]
        public int SaludConsultanteID { get; set; }
        public string PreguntasSaludConsultante{get; set;}
        public RespuestasSaludConsultante RespuestasSaludConsultante { get; set; }
        public string RespuestaCualConsultante { get; set; }
        public virtual ICollection<PersonaConDiscapacidad> PersonaConDiscapacidads { get; set; }

    }
    public enum RespuestasSaludConsultante
    {
        Si = 1,
        No = 2
    }
    public class ListadoSaludConsultante
    {
        public int SaludConsultanteID { get; set; }
        public string PreguntasSaludConsultante { get; set; }
        public RespuestasSaludConsultante RespuestasSaludConsultante { get; set; }
        public string RespuestaCualConsultante { get; set; }
    }
}