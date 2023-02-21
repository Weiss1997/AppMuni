using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class EdadPercentilMeses
    {

        [Key]
        public int PercentilEdadID { get; set; }

        public string EdadFormularioDescripcion { get; set; }

        public int TipoPercentil { get; set; }//1-PERCENTIL 75, 2-PERCENTIL 90


        public bool Eliminado { get; set; }

        public virtual ICollection<Preguntas> Preguntas { get; set; }
    }

    public class ListadoEdadPercentil
    {
        public int PercentilEdadID { get; set; }
        public string EdadFormularioDescripcion { get; set; }
        public int TipoPercentil { get; set; }

        public string percentiltipo { get; set; }

    }

}