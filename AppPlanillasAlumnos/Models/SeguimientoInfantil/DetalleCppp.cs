using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class DetalleCppp
    {
        [Key]
        public int DetalleCpppID { get; set; }

        public int FormularioCpppID { get; set; }

        public int PreguntasID { get; set; }
        public int PercentilEdadID { get; set; }

        public OpcionCumplimiento OpcionCumplimiento { get; set; }

        public bool Cumple { get; set; }

        public virtual Preguntas Pregunta { get; set; }

        public virtual FormularioCPPP FormularioCPPP { get; set; }

    }

    public class ListadoPreguntasFormularioCppp
    {
        public int DetalleCpppID { get; set; }
        public bool Cumple { get; set; }
        public int PreguntasID { get; set; }
        public string PreguntasNombre { get; set; }
        public OpcionCumplimiento OpcionCumplimiento { get; set; }

        public OpcionRespuesta OpcionRespuesta { get; set; }
    }

    public class ListadoDetalleCppp
    {
        public string PreguntaNombre { get; set; }
        public int PercentilEdadID { get; set; }
        public string EdadFormularioDescripcion { get; set; }

    }

}