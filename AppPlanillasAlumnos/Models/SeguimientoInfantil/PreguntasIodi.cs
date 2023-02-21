using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class PreguntasIodi
    {
        [Key]
        public int PreguntasIodiID { get; set; }

        public string PreguntasIodiDescripcion { get; set; }

        public int PreguntasIodiEdadID { get; set; }

        public int PreguntasIodiclasificacionID { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<DetalleDesarrolloInfantil> DetalleDesarrolloInfantil { get; set; }



    }
    public class ListadoPreguntasIodi
    {
        public int PreguntasIodiID { get; set; }
        public string PreguntasIodiDescripcion { get; set; }
        public int PreguntasIodiEdadID { get; set; }
        public string PreguntasIodiEdadDescripcion { get; set; }
        public int PreguntasIodiclasificacionID { get; set; }
        public string PreguntasIodiclasificacion { get; set; }
    }
}