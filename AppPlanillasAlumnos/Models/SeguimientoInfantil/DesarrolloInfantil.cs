using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class DesarrolloInfantil
    {
        [Key]
        public int DesarrolloInfantilID { get; set; }
        public int PersonaID { get; set; }
        public string DesarrolloInfantilEdadGestionalAlNacer { get; set; }

        public string DesarrolloInfantilObservacion { get; set; }
        public bool Eliminado { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual ICollection<DetalleDesarrolloInfantil> DetalleDesarrolloInfantil { get; set; }

    }
    public class ListadoDesarrolloInfantil
    {
        public int DesarrolloInfantilID { get; set; }
        public int PersonaID { get; set; }
        public string PersonaApellidoNombre { get; set; }
        public string PersonaFechaNacimientoString { get; set; }
        public string DesarrolloInfantilEdadGestionalAlNacer { get; set; }

        public string DesarrolloInfantilObservacion { get; set; }
        public List<ListadoDetalleDesarrolloInfantil> ListadoDetalleDesarrolloInfantil { get; set; }
    }
    public class ListadoDetalleDesarrolloInfantil
    {
        public int DetalleDesarrolloInfantilID { get; set; }
        public int DesarrolloInfantilID { get; set; }
        public int PreguntasIodiID { get; set; }
        public string PreguntasIodiDescripcion { get; set; }
        public int CuadroColorUno { get; set; }
        public int CuadroColorDos { get; set; }
        public int CuadroColorTres { get; set; }
        public int CuadroColorCuatro { get; set; }
        public int CuadroColorCinco { get; set; }
        public int CuadroColorSeis { get; set; }
        public int CuadroColorSiete { get; set; }
        public int CuadroColorOcho { get; set; }
        public int CuadroColorNueve { get; set; }
        public int CuadroColorDiez { get; set; }
        public int CuadroColorOnce { get; set; }
        public int CuadroColorDoce { get; set; }
        public int CuadroColorTrece { get; set; }
        public int CuadroColorCatorce { get; set; }
        public int CuadroColorQuince { get; set; }
        public int CuadroColorDieciseis { get; set; }
    }
}