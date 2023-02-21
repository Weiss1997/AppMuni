using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Data
{
    public class AppPlanillasAlumnosContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AppPlanillasAlumnosContext() : base("name=AppPlanillasAlumnosContext")
        {
        }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.DatosAlumnos> DatosAlumnos { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Persona> Personas { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Escuela > Escuelas { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Especializacion> Especializacions { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.DatosDeAdmision> DatosDeAdmisions { get; set; }

        //public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Tratamiento> Tratamientoes { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Profesional> Profesionals { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Paciente> Pacientes { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.GrupoFamiliar> GrupoFamiliars { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Tratamiento> Tratamientos { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.TrayectoriaEscolar> TrayectoriaEscolars { get; set; } 

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Derivaciones> Derivaciones { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Discapacitados.SituacionHabitacional> SituacionHabitacional { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Discapacitados.TipodeDiscapacidad> TipodeDiscapacidads  { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Discapacitados.AccesibilidadAlServicio> AccesibilidadAlServicios { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Discapacitados.PersonaConDiscapacidad> PersonaConDiscapacidads { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Discapacitados.SectorVivienda> SectorViviendas { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Discapacitados.CaracteristicaSector> CaracteristicaSectors { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Discapacitados.NivelEducativo> NivelEducativoes { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.Preguntas> Preguntas { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.Formularios> Formularios { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.DetalleFormulario> DetalleFormularios { get; set; }


        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.PersonaldeInstitutos> PersonaldeInstitutos { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Provincias> Provincias { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.EdadFormulario> EdadFormularios { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.FormularioCPPP> FormularioCPPPs { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.InfantesEvaluados> InfantesEvaluados { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Localidades> Localidades { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Discapacitados.RelacionInstitutoYPersona> RelacioneInstitutoYPersonas { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.Discapacitados.TablaRelacionSitHabitYPersDiscapacidad> TablaRelacionSitHabitYPersDiscapacidades { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.EdadPercentilMeses> EdadPercentilMeses { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.PreguntasIodi> PreguntasIodis { get; set; }

        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.DesarrolloInfantil> DesarrolloInfantils { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.DetalleDesarrolloInfantil> DetallesDesarrolloInfantil { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.SeguimientoInfantil.DetalleCppp> DetalleCppps { get; set; }
        public System.Data.Entity.DbSet<AppPlanillasAlumnos.Models.PersonaSistema> PersonaSistemas { get; set; }
    }
}
