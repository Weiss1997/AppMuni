using AppPlanillasAlumnos.Models.Discapacitados;
using AppPlanillasAlumnos.Models.SeguimientoInfantil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class Escuela
    {
        [Key]

        public int EscuelaID { get; set; }

        [Display(Name = "Nombre de la escuela")]
        [Required(ErrorMessage = "Debe ingresar un {0}")]
        [StringLength(200, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string EscuelaNombre { get; set; }


        [Display(Name = "Telefono de la Escuela")]
        [Required(ErrorMessage = "Debe ingresar un {0}")]
        [StringLength(300, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string EscuelaTelefono { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Debe ingresar un {0}")]
        [StringLength(300, ErrorMessage = "La {0} debe tener como máximo {1} caracteres.")]
        public string EscuelaDireccion { get; set; }

        [Display(Name = "Presidente")]
        [Required(ErrorMessage = "Por favor debe ingresar un Encargado o Presidente")]
        [StringLength(300, ErrorMessage = "La {0} debe tener como máximo {1} caracteres.")]
        public string EscuelaPresidente { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Por favor debe ingresar un email")]
        //Esta comentado porque en la vista aparece en blanco//
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool Eliminado { get; set; }

        public virtual ICollection<TrayectoriaEscolar> TrayectoriaEscolars { get; set; }
        public virtual ICollection<Derivaciones> Derivaciones { get; set; }
        public virtual ICollection<Formularios> Formularios { get; set; }
        public virtual ICollection<RelacionInstitutoYPersona> RelacionInstitutoYPersona { get; set; }
        public virtual ICollection<PersonaldeInstitutos> PersonaldeInstitutos { get; set; }

    }
    public class ListadoEscuela
    {
        public int EscuelaID { get; set; }
        public string EscuelaNombre { get; set; }
        public string EscuelaTelefono { get; set; }
        public string EscuelaDireccion { get; set; }
        public string EscuelaPresidente { get; set; }
        public string Email { get; set; }

    }
}