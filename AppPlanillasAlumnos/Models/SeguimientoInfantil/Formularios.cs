using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class Formularios
    {
        [Key]
      public int  FormulariosID { get; set; }
      public DateTime Fecha { get; set; }
      public string Peso { get; set; }
      public int NivelEducativoID { get; set; }
      public int PersonaID { get; set; }
      public int EscuelaID { get; set; }
      public int TipoFormularioID { get; set; }
      public string PersonaACargoNombreApellido { get; set; }
      public string PersonaACargoParentezco { get; set; }
      public string PersonaACargoEdad { get; set; }
      public string PersonaACargoDireccion { get; set; }
      public string PersonaACargoBarrio { get; set; }
      public string PersonaACargoLocalidad { get; set; }
      public string PersonaACargoTelefono { get; set; }
      public int EdadFormularioID { get; set; }
      public bool Eliminado { get; set; }
      public virtual Escuela Escuela { get; set; }
      public virtual Persona Persona { get; set; }
      public virtual ICollection<DetalleFormulario> DetalleFormularios { get; set; }
    }
    public class ListadoFormularios
    {
        public int FormulariosID { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaString { get; set; }
        public string Peso { get; set; }
        public int NivelEducativoID { get; set; }
        public int PersonaID { get; set; }
        public string PersonaApellidoNombre { get; set; }
        public int PersonaDNI { get; set; }
        public int PersonaEdad { get; set; }
        public DateTime PersonaFechaNacimiento { get; set; }
        public string PersonaFechaNacimientoString { get; set; }
        public int EscuelaID { get; set; }
        public string EscuelaNombre { get; set; }
        public int TipoFormularioID { get; set; }
        public string PersonaACargoNombreApellido { get; set; }
        public string PersonaACargoParentezco { get; set; }
        public string PersonaACargoEdad { get; set; }
        public string PersonaACargoDireccion { get; set; }
        public string PersonaACargoBarrio { get; set; }
        public string PersonaACargoLocalidad { get; set; }
        public string PersonaACargoTelefono { get; set; }
        public int EdadFormularioID { get; set; }
        public List<ListadoPreguntasFormulario> ListadoPreguntasFormulario { get; set; }
    }
    public class ListadoPreguntasFormulario
    {
        public int DetalleFormularioID { get; set; }
        public int PreguntasID { get; set; }
        public string PreguntasNombre { get; set; }
        public OpcionRespuesta OpcionRespuesta { get; set; }

    }
}