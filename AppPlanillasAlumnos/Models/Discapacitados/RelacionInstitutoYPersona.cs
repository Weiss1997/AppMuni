using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class RelacionInstitutoYPersona
    {
        [Key]
        public int RelacionInstitutoYPersonaID { get; set; }
        public int PersonaID { get; set; }
        public int EscuelaID { get; set; }
        public virtual Escuela Escuela { get; set; }
        public virtual Persona Persona { get; set; }
    }
    public class ListadoRelacionInstitutoYPersona
    {
        public int RelacionInstitutoYPersonaID { get; set; }
        public ListadoPersonas Persona { get; set; }
        public ListadoEscuela Escuela { get; set; }

        //public string EscuelaNombre { get; set; }
        //public int EscuelaID { get; set; }
    }
}