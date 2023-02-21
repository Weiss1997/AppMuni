using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class Provincias
    {
        [Key]
        public int ProvinciasID { get; set; }

        [Display(Name = "Provincias")]
        public string ProvinciasNombre { get; set; }


        public virtual ICollection<Localidades> Localidades { get; set; }
    }

    public class ListadoProvincias {
        public int ProvinciasID { get; set; }
        public string ProvinciasNombre { get; set; }

    }
}