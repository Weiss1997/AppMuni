using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.SeguimientoInfantil
{
    public class InfantesEvaluados
    {
        [Key]
        public int InfantesEvaluadosID { get; set; }
        public DateTime InfantesEvaluadosFecha { get; set; }
        public string InfantesEvaluadosHistorialClinico { get; set; }
        public int PersonaID { get; set; }
        public string InfantesEvaluadosEdadCorregidaPrematuro { get; set; }
        public string InfantesEvaluadosRespuestaPrueba { get; set; }
        public string InfantesEvaluadosObservacion { get; set; }
        public string InfantesEvaluadosProximoControl { get; set; }
        public DateTime InfantesEvaluadosSegundoControl { get; set; }
        public string InfantesEvaluadosRespuestaPrueba2 { get; set; }
        public string InfantesEvaluadosObservacion2 { get; set; }
        public DateTime InfantesEvaluadosTercerControl { get; set; }
        public string InfantesEvaluadosRespuestaPrueba3 { get; set; }
        public string InfantesEvaluadosObservacion3 { get; set; }
        public DateTime InfantesEvaluadosCuartoControl { get; set; }
        public string InfantesEvaluadosRespuestaPrueba4 { get; set; }
        public string InfantesEvaluadosObservacion4 { get; set; }
        public bool Eliminado { get; set; }

    }
    public class ListadoInfantesEvaluados
    {
        public int InfantesEvaluadosID { get; set; }
        public string InfantesEvaluadosFechaString { get; set; }
        public string InfantesEvaluadosHistorialClinico { get; set; }
        public int PersonaID { get; set; }
        public string PersonaApellidoNombre { get; set; }
        public string PersonaFechaNacimientoString { get; set; }
        public Sexo PersonaSexo { get; set; }
        public string PersonaSexoString { get; set; }
        
        public int PersonaEdad { get; set; }
        public string InfantesEvaluadosEdadCorregidaPrematuro { get; set; }
        public string InfantesEvaluadosRespuestaPrueba { get; set; }
        public string InfantesEvaluadosObservacion { get; set; }
        public string InfantesEvaluadosProximoControl { get; set; }
        public DateTime InfantesEvaluadosSegundoControl { get; set; }
        public string InfantesEvaluadosSegundoControlString { get; set; }
        public string InfantesEvaluadosRespuestaPrueba2 { get; set; }
        public string InfantesEvaluadosObservacion2 { get; set; }
        public DateTime InfantesEvaluadosTercerControl { get; set; }
        public string InfantesEvaluadosTercerControlString { get; set; }
        public string InfantesEvaluadosRespuestaPrueba3 { get; set; }
        public string InfantesEvaluadosObservacion3 { get; set; }
        public DateTime InfantesEvaluadosCuartoControl { get; set; }
        public string InfantesEvaluadosCuartoControlString { get; set; }
        public string InfantesEvaluadosRespuestaPrueba4 { get; set; }
        public string InfantesEvaluadosObservacion4 { get; set; }
        public List<ListadoPersonas> Personas { get; set; }
    }
}