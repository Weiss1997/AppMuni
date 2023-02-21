namespace AppPlanillasAlumnos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppPlanillasAlumnos.Data.AppPlanillasAlumnosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "AppPlanillasAlumnos.Data.AppPlanillasAlumnosContext";

        }

        protected override void Seed(AppPlanillasAlumnos.Data.AppPlanillasAlumnosContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
            context.AccesibilidadAlServicios.AddOrUpdate(i => i.AccesibilidadDescripcion,
                    new Models.Discapacitados.AccesibilidadAlServicio
                    {
                        AccesibilidadDescripcion = "Por una Persona Conocida"
                    },
                    new Models.Discapacitados.AccesibilidadAlServicio
                    {
                        AccesibilidadDescripcion = "Por los medios de comunicacion"
                    },
                    new Models.Discapacitados.AccesibilidadAlServicio
                    {
                        AccesibilidadDescripcion = "Por la Escuela, Gabinete escolar"
                    },
                    new Models.Discapacitados.AccesibilidadAlServicio
                    {
                        AccesibilidadDescripcion = "Por el Juzgado"
                    },
                    new Models.Discapacitados.AccesibilidadAlServicio
                    {
                        AccesibilidadDescripcion = "Por la Policia"
                    },
                    new Models.Discapacitados.AccesibilidadAlServicio
                    {
                        AccesibilidadDescripcion = "Por otros Servicios o Institución"
                    }
             );

            context.TipodeDiscapacidads.AddOrUpdate(i => i.NombredelaDiscapacidad,
                    new Models.Discapacitados.TipodeDiscapacidad
                    {
                        NombredelaDiscapacidad = "Mental"
                    },
                    new Models.Discapacitados.TipodeDiscapacidad
                    {
                        NombredelaDiscapacidad = "Motriz"
                    },
                    new Models.Discapacitados.TipodeDiscapacidad
                    {
                        NombredelaDiscapacidad = "Visual"
                    },
                    new Models.Discapacitados.TipodeDiscapacidad
                    {
                        NombredelaDiscapacidad = "Auditiva"
                    },
                    new Models.Discapacitados.TipodeDiscapacidad
                    {
                        NombredelaDiscapacidad = "Visceral"
                    }
                );
            context.SectorViviendas.AddOrUpdate(i => i.NombreSectorVivienda,
                    new Models.Discapacitados.SectorVivienda
                    {
                        NombreSectorVivienda = "Vivienda"
                    },
                    new Models.Discapacitados.SectorVivienda
                    {
                        NombreSectorVivienda = "Baño"
                    },
                    new Models.Discapacitados.SectorVivienda
                    {
                        NombreSectorVivienda = "Piso"
                    },
                    new Models.Discapacitados.SectorVivienda
                    {
                        NombreSectorVivienda = "Agua"
                    },
                    new Models.Discapacitados.SectorVivienda
                    {
                        NombreSectorVivienda = "Aberturas"
                    }
                );
            context.CaracteristicaSectors.AddOrUpdate(i => i.NombreCaracteristicaSector,
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Propia"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Alquilada"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Prestada"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Cedida"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Instalado"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Letrina"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Adaptado"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Mosaico"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "entrepiso"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Rampa"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Bombeador"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Potable"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Pico"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Aluminio"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Chapa"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Madera"
                    },
                    new Models.Discapacitados.CaracteristicaSector
                    {
                        NombreCaracteristicaSector = "Adaptadas"
                    }
                );
            context.SituacionHabitacional.AddOrUpdate(i => i.SituacionHabitacionalID,
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 1,
                        SectorViviendaID = 1,
                        CaracteristicaSectorID = 1
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 2,
                        SectorViviendaID = 1,
                        CaracteristicaSectorID = 2,
                        Observacion=true
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 3,
                        SectorViviendaID = 1,
                        CaracteristicaSectorID = 3
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 4,
                        SectorViviendaID = 1,
                        CaracteristicaSectorID = 4
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 5,
                        SectorViviendaID = 2,
                        CaracteristicaSectorID = 5
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 6,
                        SectorViviendaID = 2,
                        CaracteristicaSectorID = 6
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 7,
                        SectorViviendaID = 2,
                        CaracteristicaSectorID = 7
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 8,
                        SectorViviendaID = 3,
                        CaracteristicaSectorID = 8
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 9,
                        SectorViviendaID = 3,
                        CaracteristicaSectorID = 9
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 10,
                        SectorViviendaID = 3,
                        CaracteristicaSectorID = 10
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 11,
                        SectorViviendaID = 4,
                        CaracteristicaSectorID = 11
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 12,
                        SectorViviendaID = 4,
                        CaracteristicaSectorID = 12
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 13,
                        SectorViviendaID = 4,
                        CaracteristicaSectorID = 13
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 14,
                        SectorViviendaID = 5,
                        CaracteristicaSectorID = 14
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 15,
                        SectorViviendaID = 5,
                        CaracteristicaSectorID = 15
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 16,
                        SectorViviendaID = 5,
                        CaracteristicaSectorID = 16
                    },
                    new Models.Discapacitados.SituacionHabitacional
                    {
                        SituacionHabitacionalID = 17,
                        SectorViviendaID = 5,
                        CaracteristicaSectorID = 17
                    }
                );
            context.NivelEducativoes.AddOrUpdate(i => i.Niveles,
                   new Models.Discapacitados.NivelEducativo
                   {

                       Niveles = "Nivel Inicial"
                   },
                   new Models.Discapacitados.NivelEducativo
                   {

                       Niveles = "Primaria Incompleta"
                   },
                    new Models.Discapacitados.NivelEducativo
                    {

                        Niveles = "Primaria Completa"
                    },
                    new Models.Discapacitados.NivelEducativo
                    {

                        Niveles = "Secundaria Incompleta"
                    },
                    new Models.Discapacitados.NivelEducativo
                    {

                        Niveles = "Secundaria Completa"
                    },
                    new Models.Discapacitados.NivelEducativo
                    {

                        Niveles = "Terc./Univ. Incompleta"
                    },
                    new Models.Discapacitados.NivelEducativo
                    {

                        Niveles = "Terc./Univ. Completa"
                    }
               );
            context.Provincias.AddOrUpdate(i => i.ProvinciasNombre,
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Buenos Aires"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Catamarca"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Chaco"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Chubut"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Cordoba"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Corrientes"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Entre Rios"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Formosa"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Jujuy"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "La Pampa"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "La Rioja"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Mendoza"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Misiones"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Neuquén"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Rio Negro"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Salta"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "San Juan"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "San Luis"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Santa Cruz"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Santa Fe"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Santiago del Estero"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Tierra del Fuego, Antártida e Islas del Atlántico Sur"
                        },
                        new Models.Provincias
                        {

                            ProvinciasNombre = "Tucumán"
                        }
                );



        }
    }
}
