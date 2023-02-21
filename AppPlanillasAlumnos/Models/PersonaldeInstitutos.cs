using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class PersonaldeInstitutos
    {
        [Key]
        public int PersonaldeInstitutosID { get; set; }
        public string CargodentrodelaInstitucion { get; set; }
        public string Observaciones { get; set; }
        public int PersonaID { get; set; }
        public int EscuelaID { get; set; }
        public Persona Persona { get; set; }
        public Escuela Escuela { get; set; }
        public bool Eliminado { get; set; }
    }

    public class ListadoPersonalInstituto {
        public int PersonaldeInstitutosID { get; set; }
        public string CargodentrodelaInstitucion { get; set; }
        public string Observaciones { get; set; }
        public ListadoPersonas Persona { get; set; }
        public ListadoEscuela Escuela { get; set; }
    }
}