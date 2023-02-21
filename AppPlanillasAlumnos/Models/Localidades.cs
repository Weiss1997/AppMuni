using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class Localidades
    {
        [Key]
        public int LocalidadesID { get; set; }
        [Display(Name = "Localidad")]
        public string LocalidadesNombre { get; set; }
         [Display(Name = "Departamento")]
        public string LocalidadesDepartamento { get; set; }
        [Display(Name = "Provincia")]
        public int ProvinciasID { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }

        public Provincias Provincia { get; set; }
        public bool Eliminado { get; set; }
    }
    public class ListadoLocalidades 
    {
        public int LocalidadesID { get; set; }
        public string LocalidadesNombre { get; set; }
        public string LocalidadesNombreCompleto { get; set; }
        public string LocalidadesDepartamento { get; set; }
        public int ProvinciasID { get; set; }
        public string ProvinciasNombre { get; set; }
        public ListadoProvincias Provincia { get; set; }
       

    }
}