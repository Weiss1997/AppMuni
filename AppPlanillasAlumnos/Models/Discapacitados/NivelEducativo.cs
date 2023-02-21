using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class NivelEducativo
    {
        [Key]
        public int NivelEducativoID {get;set;}
        public string Niveles { get; set; }

    }
    public class ListadoNivelEducativo
    {
        public int NivelEducativoID { get; set; }
        public string Niveles { get; set; }
    }
}