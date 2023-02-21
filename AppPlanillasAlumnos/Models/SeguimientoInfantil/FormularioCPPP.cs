using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class FormularioCPPP
    {
        public int FormularioCpppID { get; set; }
        public int ProfesionalID { get; set; }
        public int TipoFormularioID { get; set; }
        public string PercentilDescripcion { get; set; }
        public int PersonaID { get; set; }
        public bool Pasa { get; set; }
        public string Observacion { get; set; }
        public bool Eliminado { get; set; }

        public virtual Profesional Profesional { get; set; }
        public virtual ICollection<DetalleCppp> DetallesCppp { get; set; }
    }

    public class ListadoFormularioCppp
    {
        public int FormularioCpppID { get; set; }
        public int TipoFormularioID { get; set; }
        public int PersonaID { get; set; }
        public int ProfesionalID { get; set; }
        public string PersonaApellidoNombreProfesional { get; set; }
        public string PersonaApellidoNombrePersona { get; set; }
        public bool Pasa { get; set; }
        public string pasabool { get; set; }
        public string Observacion { get; set; }

        public List<ListadoPreguntasFormularioCppp> ListadoPreguntasFormularioCppp { get; set; }

        public  ListadoProfesionales Profesionales { get; set; }

        public ListadoPersonas Persona { get; set; }

    }

    public enum OpcionCumplimiento
    {
        CUMPLE,
        NOCUMPLE
    }



}