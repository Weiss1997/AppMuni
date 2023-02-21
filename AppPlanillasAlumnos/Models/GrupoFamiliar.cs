using AppPlanillasAlumnos.Models.Discapacitados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class GrupoFamiliar
    {

        [Key]
        public int GrupoFamiliarID { get; set; }

        [Display(Name = "Apellido y Nombre")]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string GrupoFamiliarApellidoNombre { get; set; }

        [Display(Name = "D.N.I.")]
        [Required(ErrorMessage = "Debe ingresar un DNI")]
        public int GrupoFamiliarDNI { get; set; }

        [Display(Name = "Salud")]
        public string GrupoFamiliarSalud { get; set; }

        [Display(Name = "Ingresos")]
        public int GrupoFamiliarIngresos { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime GrupoFamiliarNacimiento { get; set; }

        [NotMapped]
        public int Edad { get { return DateTime.Today.AddTicks(-GrupoFamiliarNacimiento.Ticks).Year - 1; } }

        [Display(Name = "Vinculo")]
        public string GrupoFamiliarVinculo { get; set; }

        [Display(Name = "Escolaridad")]
        public string GrupoFamiliarEscolaridad { get; set; }


        [Display(Name = "Ocupacion")]
        public string GrupoFamiliarOcupacion { get; set; }

        public Sexo GrupoFamiliarSexo { get; set; }
        public int PersonaID { get; set; }
        public virtual Persona Persona { get; set; }
        public bool Eliminado { get; set; }
    }

    public class ListadoGrupoFamiliar {

        public int GrupoFamiliarID { get; set; }
        public string GrupoFamiliarApellidoNombre { get; set; }
        public DateTime GrupoFamiliarNacimiento { get; set; }
        public string GrupoFamiliarNacimientoString {get; set;}
        public Sexo GrupoFamiliarSexo { get; set; }

        public string GrupoFamiliarSexoString { get; set; }
        public string GrupoFamiliarVinculo { get; set; }
        public string GrupoFamiliarEscolaridad { get; set; }
        public int GrupoFamiliarDNI { get; set; }
        public string GrupoFamiliarOcupacion { get; set; }
        public string GrupoFamiliarSalud { get; set; }
        public int GrupoFamiliarIngresos { get; set; }

        public ListadoPersonas Personas { get; set; }
    }
}