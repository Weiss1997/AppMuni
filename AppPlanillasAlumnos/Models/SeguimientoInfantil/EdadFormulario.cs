using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class EdadFormulario
    {
        [Key]

        public int EdadFormularioID { get; set; }

        public string EdadFormularioDescripcion { get; set; }
        public int TipoFormularioID { get; set; }

        public bool Eliminado { get; set; }

    }
    public class ListadoEdadFormularios
    {
        public int EdadFormularioID { get; set; }
        public string EdadFormularioDescripcion { get; set; }
        public int TipoFormularioID { get; set; }
    }
}