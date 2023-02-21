using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class GrupoFamiliarTemporal
    {
        [Key]
        public int GrupoFamiliarTemporalID { get; set; }

        [Display(Name = "Apellido y Nombre")]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string GrupoFamiliarApellidoNombre { get; set; }

        [Display(Name = "Edad")]
        public string GrupoFamiliarEdad { get; set; }

        [Display(Name = "Vinculo")]
        public string GrupoFamiliarVinculo { get; set; }

        [Display(Name = "Escolaridad")]
        public string GrupoFamiliarEscolaridad { get; set; }

        [Display(Name = "Ocupacion")]
        public string GrupoFamiliarOcupacion { get; set; }
    }
}