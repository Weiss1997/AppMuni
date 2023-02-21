using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class Derivaciones
    {
        [Key]

        public int DerivacionesID { get; set; }

        public int DerivacionesNiveles { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DerivacionesFecha { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DerivacionesAnioIngresoNivel { get; set; } 

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DerivacionesAnioIngresoNivelActual { get; set; } 
        public string DerivacionesSalaCurso { get; set; } 
        public string DerivacionesObservaciones { get; set; }

        public string DerivacionesInstitucionAsistio { get; set; } 

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DerivacionesAnioIngresoInstitucionActual { get; set; }
        public string DerivacionesDiferentesInstituaciones { get; set; } 

        public bool DerivacionesRehizo { get; set; }

        public bool DerivacionesRepitencia { get; set; } 
        public string DerivacionesGradoAnioRepitencia { get; set; }
        public string DerivacionesMotivosRepitencia { get; set; }

        public bool DerivacionesInasistencias { get; set; } 
        public string DerivacionesMotivosInasistencias { get; set; }

        public bool DerivacionesDesercion{ get; set; } 
        public string DerivacionesMotivosDesercion { get; set; }

        public bool DerivacionesAcompañamientoPedagogicoTerapeutico{ get; set; } 
        public string DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad { get; set; }

        public string DerivacionesSalaAsiste { get; set; } 

        public string DerivacionesTurnoJornada { get; set; } 

        public string DerivacionesMotivosSecundario { get; set; } 

        public string DerivacionesFortalezasNinio { get; set; } 

        public string DerivacionesDificultades { get; set; } 

        public bool DerivacionesAcompañamientoPedagogicoTerapeuticoActualmente{ get; set; } 
        public string DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidadActual { get; set; } 

        public string DerivacionesEstrategiasResultados { get; set; } 

        public string DerivacionesNombreDocente { get; set; } 

        public string DerivacionesAreaCurricular { get; set; } 

        public string DerivacionesOtrosDocentesInformacion { get; set; }  

        public int PersonaID { get; set; }
        public virtual Persona Persona { get; set; }

        public int EscuelaID { get; set; }
        public virtual Escuela Escuela { get; set; }

        public bool Eliminado { get; set; }


    } 

    public class ListadoDerivaciones
    {
        public int DerivacionesID { get; set; }

        public int DerivacionesNiveles { get; set; }
        public string DerivacionesFechaString { get; set; }
        public string DerivacionesAnioIngresoNivelString { get; set; }
        public string DerivacionesAnioIngresoNivelActualString { get; set; } 

        public string DerivacionesSalaCurso { get; set; } 
        public string DerivacionesObservaciones { get; set; }

        public string DerivacionesInstitucionAsistio { get; set; } 

        public string DerivacionesAnioIngresoInstitucionActualString { get; set; } 
        public string DerivacionesDiferentesInstituaciones { get; set; } 

        public bool DerivacionesRehizo { get; set; }

        public bool DerivacionesRepitencia { get; set; }  
        public string DerivacionesGradoAnioRepitencia { get; set; }
        public string DerivacionesMotivosRepitencia { get; set; }

        public bool DerivacionesInasistencias { get; set; } 
        public string DerivacionesMotivosInasistencias { get; set; }

        public bool DerivacionesDesercion { get; set; }
        public string DerivacionesMotivosDesercion { get; set; }

        public bool DerivacionesAcompañamientoPedagogicoTerapeutico { get; set; } 
        public string DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad { get; set; }

        public string DerivacionesSalaAsiste { get; set; }

        public string DerivacionesTurnoJornada { get; set; } 

        public string DerivacionesMotivosSecundario { get; set; } 

        public string DerivacionesFortalezasNinio { get; set; } 

        public string DerivacionesDificultades { get; set; } 

        public bool DerivacionesAcompañamientoPedagogicoTerapeuticoActualmente { get; set; } 
        public string DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidadActual { get; set; }

        public string DerivacionesEstrategiasResultados { get; set; }
        public string DerivacionesNombreDocente { get; set; } 

        public string DerivacionesAreaCurricular { get; set; }

        public string DerivacionesOtrosDocentesInformacion { get; set; } 
        public ListadoPersonas Persona { get; set; }
        public ListadoEscuela Escuela { get; set; }

    }

}