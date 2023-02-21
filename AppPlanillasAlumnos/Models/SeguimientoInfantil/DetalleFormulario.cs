using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class DetalleFormulario
    {
        [Key]
        public int DetalleFormularioID { get; set; }
        public int PreguntasID { get; set; }
        public int FormulariosID { get; set; }

        public OpcionRespuesta OpcionRespuesta { get; set; }

        public virtual Formularios Formularios { get; set; }

        public virtual Preguntas Preguntas { get; set; }

    }
    public enum OpcionRespuesta
    {
        No,
        Si,
        Nose
    }

}