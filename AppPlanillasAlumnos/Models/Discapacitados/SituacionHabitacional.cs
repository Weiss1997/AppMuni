using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models.Discapacitados
{
    public class SituacionHabitacional
    {
        [Key]
        public int SituacionHabitacionalID { get; set; }
        public virtual SectorVivienda SectorVivienda { get; set; }
        public int SectorViviendaID { get; set; }
        public virtual CaracteristicaSector CaracteristicaSector { get; set; }
        public int CaracteristicaSectorID { get; set; }
        public bool Observacion { get; set; }
        public virtual ICollection<TablaRelacionSitHabitYPersDiscapacidad> TablaRelacionSitHabitYPersDiscapacidad { get; set; }
    }

    public class SectorVivienda { 
    [Key]
        public int SectorViviendaID { get; set; }
        public string NombreSectorVivienda { get; set; }
        public virtual ICollection<SituacionHabitacional> SituacionHabitacionals { get; set; }
    }


    public class CaracteristicaSector {
        [Key]
        public int CaracteristicaSectorID { get; set; }
        public string NombreCaracteristicaSector { get; set; }
        public virtual ICollection<SituacionHabitacional> SituacionHabitacionals { get; set; }
    }

    //CLASES SOLO DE VISTAS (NO SON TABLAS EN BASE DE DATOS)
    public class VistaSituacionHabitacional
    {
        public int SectorViviendaID { get; set; }
        public string NombreSectorVivienda { get; set; }

        public List<VistaCaracteristicaSector> Caracteristicas { get; set; }
    }

    //CLASES SOLO DE VISTAS (NO SON TABLAS EN BASE DE DATOS)
    public class VistaCaracteristicaSector
    {
        public int SituacionHabitacionalID { get; set; }
        public int CaracteristicaSectorID { get; set; }
        public string NombreCaracteristicaSector { get; set; }
        public bool Observacion { get; set; }
    }
    //CLASES SOLO DE VISTAS (NO SON TABLAS EN BASE DE DATOS)
    public class ListadoDeCaracteristicasSelecionadas {
        public int SituacionHabitacionalID { get; set; }
        public int SectorSeleccionado { get; set; }
        public bool Observacion { get; set; }
        public string ObservacionString { get; set; }
    }
}