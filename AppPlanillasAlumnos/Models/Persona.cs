using AppPlanillasAlumnos.Models.Discapacitados;
using AppPlanillasAlumnos.Models.SeguimientoInfantil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }

        [Display(Name = "Apellido y Nombre de la Persona")]
        [Required(ErrorMessage = "Debe ingresar un {0}")]
        [StringLength(200, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string PersonaApellidoNombre { get; set; }

        [Display(Name = "Telefono de contacto")]
        [StringLength(300, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.")]
        public string PersonaTelefono { get; set; }

        [Display(Name = "D.N.I.")]
        public int PersonaDNI { get; set; } 

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Debe ingresar una fecha")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime PersonaFechaNacimiento { get; set; }

        [Display(Name = "Direccion")]
        [StringLength(300, ErrorMessage = "La {0} debe tener como máximo {1} caracteres.")]
        public string PersonaDireccion { get; set; }


        [Display(Name = "Correo Electronico")]
        public string PersonaCorreo { get; set; }

        [Display(Name = "Covid-19")]
        public bool PersonaCovid { get; set; }

        [Display(Name = "Obra Social")]
        public bool PersonaObraSocial { get; set; }

        [Display(Name = "Cual")]
        public string ObraSocialCual { get; set; }

        public Sexo PersonaSexo { get; set; }

        public bool Eliminado { get; set; }

        [NotMapped]
        public int Edad { get { return DateTime.Today.AddTicks(-PersonaFechaNacimiento.Ticks).Year - 1; } }

        public virtual ICollection<Paciente> Pacientes { get; set; }
        public virtual ICollection<Profesional>Profesionals { get; set; }
        public virtual ICollection<PersonaConDiscapacidad> PersonaConDiscapacidads { get; set; }
        public virtual ICollection<Formularios> Formularios { get; set; }
        public virtual ICollection<GrupoFamiliar> GrupoFamiliar { get; set; }

        public virtual ICollection<Derivaciones> Derivaciones { get; set; }
        public virtual ICollection<PersonaldeInstitutos> PersonaldeInstitutos { get; set; }
        public virtual ICollection<RelacionInstitutoYPersona> RelacionInstitutoYPersona { get; set; }

        public virtual ICollection<DesarrolloInfantil> DesarrollosInfantiles { get; set; }

        public int LocalidadesID { get; set; }
        public Localidades Localidad { get; set; }

        public int PersonaSistemasID { get; set; }
        public virtual PersonaSistema PersonaSistema { get; set; }
    }


    public enum Sexo
    {
     Femenino = 1,
     Masculino = 2,
     Nobinario = 3
    }

    public class ListadoPersonas
    {
        public int PersonaID { get; set; }

        public string PersonaApellidoNombre { get; set; }

        public int PersonaDNI { get; set; }

        public int PersonaEdad { get; set; }
        public DateTime PersonaFechaNacimiento { get; set; }
        public string PersonaFechaNacimientoString { get; set; }
        public string PersonaDireccion { get; set; }
        public Sexo PersonaSexo { get; set; }
        public string PersonaSexoString { get; set; }

        public bool PersonaCovid { get; set; }
        public bool PersonaObraSocial { get; set; }
        public string PersonaTelefono { get; set; }
        public int PersonaLocalidadesID { get; set; }
        public string PersonaLocalidadNombre { get; set; }
        //public string PersonaDepartamentoNombre { get; set; }
        //public string PersonaProvinciaNombre { get; set; }
        public string PersonaCorreo { get; set; }
        public string ObraSocialCual { get; set; }
        public string EmailUsuario { get; set; }
        public string ContraseniaSistema { get; set; }
        public int PersonaSistemaID { get; set; }
        public TipoSistemas PersonaTipoSistema { get; set; }
        public List<ListadoEscuela> Escuelas { get; set; } 
 
    }
   
    
}