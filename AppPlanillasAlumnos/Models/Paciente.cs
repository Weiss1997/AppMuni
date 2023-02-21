using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class Paciente
    {

        [Key]
        public int PacienteID { get; set; }

        [Display(Name = "Datos significativos del niño: ")]
        public string PacienteDatosSignificativos { get; set; }

        [Display(Name = "Caracteristicas generales del niño:  ")]
        public string PacienteCaracteristicas { get; set; }

        [Display(Name = "Edad a la que comenzo a caminar:")]
        public int PacienteEdadCaminar { get; set; }

        [Display(Name = "Control de esfinteres: ")]
        public string PacienteControlEsfinter { get; set; }

        [Display(Name = "Lenguaje (forma de comunicarse):")]
        public string PacienteLenguaje { get; set; }

        [Display(Name = "Gestual:")]
        public string PacienteLenguajeGestual { get; set; }

        [Display(Name = "Oral:")]
        public string PacienteLenguajeOral { get; set; }

        [Display(Name = "Adquisiciones intelectuales:")]
        public string PacienteIntelecto { get; set; }

        public bool Eliminado { get; set; }

        public int PersonaID { get; set; }
        public virtual Persona Persona { get; set; }

        [NotMapped]
        public string PersonaApellidoNombre { get; set; }

        public virtual ICollection<TrayectoriaEscolar> TrayectoriaEscolars { get; set; }
        public virtual ICollection<Tratamiento> Tratamiento { get; set; }
        public virtual ICollection<DatosDeAdmision> DatosDeAdmisions { get; set; }

    }

    public class ListadoPacientes
    {
        public int PacienteID { get; set; }
        public int PersonaID { get; set; }
        public string PersonaApellidoNombre { get; set; }

        public string PacienteDatosSignificativos { get; set; }

        public string PacienteCaracteristicas { get; set; }

        public int PacienteEdadCaminar { get; set; }

        public string PacienteControlEsfinter { get; set; }

        public string PacienteLenguaje { get; set; }

        public string PacienteLenguajeGestual { get; set; }

        public string PacienteLenguajeOral { get; set; }

        public string PacienteIntelecto { get; set; }

    }
}