using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class PersonaConDiscapacidad
    {
        [Key]
        public int PersonaConDiscapacidadID { get; set; }
        public string Diagnostico { get; set; }
        public int NumeroCUD { get; set; }
        public OpcionTramite CudExistente { get; set; }
        public bool Postrado { get; set; }
        public OpcionTramite PencionPorincapacidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime VencimientoCud { get; set; }
        public bool InicioDiscapacidadNacimiento { get; set; }//SI ES 0, QUIERE DECIR QUE ES ADQUIRIDO, SI ES TRUE ES DE NACIMIENTO

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime FechaInicioDiscapacidad { get; set; }
        public string Observaciones { get; set; }
        public bool Eliminado { get; set; }

        public string NombreConsultante { get; set; }
        public string DireccionConsultante { get; set; }
        public string LocalidadConsultante { get; set; }
        public string TelefonoConsultante { get; set; }
        public string DniConsultante { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime FechaNacimientoConsultante { get; set; }


        public int GrupoFamiliarID { get; set; }


        //SALUD PERSONA CON DISCAPACIDAD
        public bool DiagnosticoEnfermedad { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR EL DETALLE
        public string DetalleDiagnosticoEnfermedad { get; set; }
        public bool TratamientoMedico { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR EL DETALLE Y LUGAR
        public string DetalleTratamientoMedico { get; set; }
        public string LugarTratamientoMedico { get; set; }
        public bool InterrumpioTratamientoMedico { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR EL TIEMPO Y MOTIVO
        public string TiempoInterrupcionTratamientoMedico { get; set; }
        public string MotivoInterrupcionTratamientoMedico { get; set; }


        //SALUD CONSULTANTE
        public bool TrastornoSuenio { get; set; }
        public bool TrastornoAlimenticio { get; set; }
        public bool IngestaAnsioAntidepre { get; set; }
        public bool ConsumioAlcoholoDroga { get; set; }
        public bool OtrosTrastornos { get; set; }
        public bool AbortoPorGolpe { get; set; }
        public bool IntentoDeSuicidio  { get; set; }

        //RED SOCIAL Y COMUNITARIA  (Personas o institucion con las que cuenta)
        public bool CuentaConParienteAQuienRecurir { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR A QUIEN
        public string AQueParienteRecurir { get; set; }
        public bool CuentaConAmigosVecinosCompanieroTrabajo { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR A QUE AMIGO
        public string QueAmigosVecinosCompanieroTrabajo { get; set; }
        public bool AsisteAIntitucionComunitaria { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR A CUAL Y CON QUIEN
        public string CualIntitucionComunitaria { get; set; }
        public string ConQuienSeContactaEnIntitucionComunitaria { get; set; }
        public bool DejoDeContactarAAlguien { get; set; }
        public string AQuienDejoDeContactar { get; set; }

        //ANTECEDENTE DE VIOLENCIA
        //Consultante
        public bool VioleciaFisicaOPiscConsultante { get; set; }
        public bool ViolacionAbusoSexualConsultante { get; set; }
        public bool TestigoDeViolenciaConsultante { get; set; }
        public bool AbandonoConsultante { get; set; }
        public bool OtrasParejasConsultante { get; set; }
        public string OtraViolenciaConsultante { get; set; }
        //Discapacitado
        public bool VioleciaFisicaOPiscDiscapacitado { get; set; }
        public bool ViolacionAbusoSexualDiscapacitado { get; set; }
        public bool TestigoDeViolenciaDiscapacitado { get; set; }
        public bool AbandonoDiscapacitado { get; set; }
        public bool OtrasParejasDiscapacitado { get; set; }
        public bool IgnoradoDiscapacitado { get; set; }
        public string OtraViolenciaDiscapacitado { get; set; }

        //NIVEL EDUCATICO

        public int NivelEducativoIDConsultante { get; set; }
        public int NivelEducativoIDDiscapacitado { get; set; }

        //SITUACION LABORAL
        public decimal IngresosFamiliarLaboral { get; set; }
        //situacion laboral Consultante
        public bool SituacionObreroConsultante { get; set; }
        public bool SituacionEmpresarioConsultante { get; set; }
        public bool SituacionEmpleadoConsultante { get; set; }
        public bool SituacionJubiladoConsultante { get; set; }
        public bool SituacionServicioDomesticoConsultante { get; set; }
        public bool SituacionProfesionalConsultante { get; set; }
        public bool SituacionNoTrabajaConsultante { get; set; }

        //situacion laboral discapacitado
        public bool SituacionObreroDiscapacitado { get; set; }
        public bool SituacionEmpresarioDiscapacitado { get; set; }
        public bool SituacionEmpleadoDiscapacitado { get; set; }
        public bool SituacionJubiladoDiscapacitado { get; set; }
        public bool SituacionServicioDomesticoDiscapacitado { get; set; }
        public bool SituacionProfesionalDiscapacitado { get; set; }
        public bool SituacionNoTrabajaDiscapacitado { get; set; }



        //RELACIONES VIRTUALES
        public virtual Persona Persona { get; set; }
        public int PersonaID { get; set; }

        public virtual AccesibilidadAlServicio AccesibilidadAlServicio { get; set; }
        public int AccesibilidadAlServicioID { get; set; }

        public virtual TipodeDiscapacidad TipodeDiscapacidad { get; set; }
        public int TipodeDiscapacidadID { get; set; }
        public virtual ICollection<TablaRelacionSitHabitYPersDiscapacidad> TablaRelacionSitHabitYPersDiscapacidad { get; set; }

    }

    public class ListadoPersonaConDiscapacidad
    {
        public int PersonaConDiscapacidadID { get; set; }
        public string Diagnostico { get; set; }
        public int NumeroCUD { get; set; }
        public OpcionTramite CudExistente { get; set; }
        public bool Postrado { get; set; }
        public OpcionTramite PencionPorincapacidad { get; set; }
        public string VencimientoCud { get; set; }
        public bool InicioDiscapacidadNacimiento { get; set; }
        public string FechaInicioDiscapacidad { get; set; }
        public string Observaciones { get; set; }
        public string NombreConsultante { get; set; }
        public string DireccionConsultante { get; set; }
        public string LocalidadConsultante { get; set; }
        public string TelefonoConsultante { get; set; }
        public string DniConsultante { get; set; }
        public string FechaNacimientoConsultante { get; set; }
        public bool DiagnosticoEnfermedad { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR EL DETALLE
        public string DetalleDiagnosticoEnfermedad { get; set; }
        public bool TratamientoMedico { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR EL DETALLE Y LUGAR
        public string DetalleTratamientoMedico { get; set; }
        public string LugarTratamientoMedico { get; set; }
        public bool InterrumpioTratamientoMedico { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR EL TIEMPO Y MOTIVO
        public string TiempoInterrupcionTratamientoMedico { get; set; }
        public string MotivoInterrupcionTratamientoMedico { get; set; }


        //SALUD CONSULTANTE
        public bool TrastornoSuenio { get; set; }
        public bool TrastornoAlimenticio { get; set; }
        public bool IngestaAnsioAntidepre { get; set; }
        public bool ConsumioAlcoholoDroga { get; set; }
        public bool OtrosTrastornos { get; set; }
        public bool AbortoPorGolpe { get; set; }
        public bool IntentoDeSuicidio { get; set; }

        //RED SOCIAL Y COMUNITARIA  (Personas o institucion con las que cuenta)
        public bool CuentaConParienteAQuienRecurir { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR A QUIEN
        public string AQueParienteRecurir { get; set; }
        public bool CuentaConAmigosVecinosCompanieroTrabajo { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR A QUE AMIGO
        public string QueAmigosVecinosCompanieroTrabajo { get; set; }
        public bool AsisteAIntitucionComunitaria { get; set; }//SI ESTE CAMPO ES TRUE, ACTIVA Y OBLIGA QUE ESCRIBIR A CUAL Y CON QUIEN
        public string CualIntitucionComunitaria { get; set; }
        public string ConQuienSeContactaEnIntitucionComunitaria { get; set; }
        public bool DejoDeContactarAAlguien { get; set; }
        public string AQuienDejoDeContactar { get; set; }


        //ANTECEDENTE DE VIOLENCIA
        //Consultante
        public bool VioleciaFisicaOPiscConsultante { get; set; }
        public bool ViolacionAbusoSexualConsultante { get; set; }
        public bool TestigoDeViolenciaConsultante { get; set; }
        public bool AbandonoConsultante { get; set; }
        public bool OtrasParejasConsultante { get; set; }
        public string OtraViolenciaConsultante { get; set; }
        //Discapacitado
        public bool VioleciaFisicaOPiscDiscapacitado { get; set; }
        public bool ViolacionAbusoSexualDiscapacitado { get; set; }
        public bool TestigoDeViolenciaDiscapacitado { get; set; }
        public bool AbandonoDiscapacitado { get; set; }
        public bool OtrasParejasDiscapacitado { get; set; }
        public bool IgnoradoDiscapacitado { get; set; }
        public string OtraViolenciaDiscapacitado { get; set; }

        //NIVEL EDUCATICO

        public int NivelEducativoIDConsultante { get; set; }

        public string NivelEducativoConsultanteString { get; set; }
        public int NivelEducativoIDDiscapacitado { get; set; }
        public string NivelEducativoDiscapacitadoString { get; set; }


        //SITUACION LABORAL
        public decimal IngresosFamiliarLaboral { get; set; }
        //situacion laboral Consultante
        public bool SituacionObreroConsultante { get; set; }
        public bool SituacionEmpresarioConsultante { get; set; }
        public bool SituacionEmpleadoConsultante { get; set; }
        public bool SituacionJubiladoConsultante { get; set; }
        public bool SituacionServicioDomesticoConsultante { get; set; }
        public bool SituacionProfesionalConsultante { get; set; }
        public bool SituacionNoTrabajaConsultante { get; set; }

        //situacion laboral discapacitado
        public bool SituacionObreroDiscapacitado { get; set; }
        public bool SituacionEmpresarioDiscapacitado { get; set; }
        public bool SituacionEmpleadoDiscapacitado { get; set; }
        public bool SituacionJubiladoDiscapacitado { get; set; }
        public bool SituacionServicioDomesticoDiscapacitado { get; set; }
        public bool SituacionProfesionalDiscapacitado { get; set; }
        public bool SituacionNoTrabajaDiscapacitado { get; set; }

        //variables utilizadas para crear el grafico de barras
        public int CantidadDePersonasDe45diasA17Anios { get; set; }
        public int CantidadDePersonasDe18aniosA59Anios { get; set; }
        public int CantidadDePersonasMayoresA60anios { get; set; }

        public ListadoPersonas Persona { get; set; }
        public ListadoGrupoFamiliar GrupoFamiliar { get; set; }
        public ListadoAccesibilidadAlServicio AccesibilidadAlServicio { get; set; }
        public ListadoTipodeDiscapacidad TipodeDiscapacidad { get; set; }
        public ListadoRelacionInstitutoYPersona RelacionInstitutoYPersona { get; set; }

    }

    public enum OpcionTramite {
        Si = 1,
        No = 2,
        Entramite = 3
    }
}