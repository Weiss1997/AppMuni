using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class Preguntas
    {
        [Key]
        public int PreguntasID { get; set; }
        [Display(Name = "Escriba la pregunta")]
        [Required]
        public string PreguntasNombre { get; set; }
        public int TipoFormularioID { get; set; }

        public int PercentilEdadID { get; set; }
        public string EdadFormularioDescripcion { get; set; }    

        public bool Eliminado { get; set; }

        public virtual EdadPercentilMeses EdadPercentilMeses { get; set; }

        public virtual ICollection<DetalleFormulario> DetalleFormularios { get; set; }

        public virtual ICollection<DetalleCppp> DetallesCppp { get; set; }
    }

    public class ListadoPreguntas 
    {
        public int PreguntasID { get; set; }
        public string PreguntasNombre { get; set; }
        public int TipoFormularioID { get; set; }
        public int PercentilEdadID { get; set; }
        public string EdadFormularioDescripcion { get; set; }

        public ListadoEdadPercentil EdadPercentil { get; set; }

    }
}