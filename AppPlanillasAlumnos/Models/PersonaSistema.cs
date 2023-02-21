using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class PersonaSistema
    {
        [Key]

        public int PersonaSistemaID { get; set; }

        [Display (Name = "Descripción")]
        [Required]
        public int PersonaID { get; set; }
        public string UsuarioID { get; set; }
        public bool Eliminado { get; set; }
        public TipoSistemas TipoSistemas { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }


    public enum TipoSistemas 
    {
        SuperUsuario = 0,
        CargaDatosGeneral = 1,
        SeguimientoInfantil = 2,
        CargaPersonasDiscapacidad = 3
    }
}