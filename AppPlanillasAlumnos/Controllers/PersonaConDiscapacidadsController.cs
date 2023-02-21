using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppPlanillasAlumnos.Data;
using AppPlanillasAlumnos.Models;
using AppPlanillasAlumnos.Models.Discapacitados;

namespace AppPlanillasAlumnos.Controllers
{
    [Authorize]
    public class PersonaConDiscapacidadsController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();


        public ActionResult Index(int? GuardadoCorrectamente)
        {
            if (GuardadoCorrectamente == 1)
            {
                return View(GuardadoCorrectamente);
            }
            return View();
        }
        public JsonResult ArmadoGraficoBarras() {

            var aniorestadesde = 0;
            var aniorestahasta = 0;
            var FechaDesde = DateTime.Now.AddYears(aniorestadesde).Year;
            var FechaHasta = DateTime.Now.AddYears(aniorestahasta).Year;
            //busca las personas con discapacidad de 45 dias hasta 17 años para completar el grafico de barras
            aniorestahasta = -17;
            FechaHasta = DateTime.Now.AddYears(aniorestahasta).Year;
            var CantEdad45diasa17anios = (from o in db.PersonaConDiscapacidads where o.Persona.PersonaFechaNacimiento.Year >= FechaHasta && o.Eliminado == false select o).Count();
            //busca las personas con discapacidad de 18 años hasta 59 años para completar el grafico de barras
            aniorestadesde = -18;
            aniorestahasta = -59;
            FechaDesde = DateTime.Now.AddYears(aniorestadesde).Year;
            FechaHasta = DateTime.Now.AddYears(aniorestahasta).Year;
            var CantEdad18aniosa59anios = (from o in db.PersonaConDiscapacidads
                                           where o.Persona.PersonaFechaNacimiento.Year >= FechaHasta && o.Persona.PersonaFechaNacimiento.Year <= FechaDesde
                                           && o.Eliminado == false
                                           select o).Count();


            //busca las personas con discapacidad mayores a 60 años para completar el grafico de barras
            aniorestadesde = -59;
            FechaDesde = DateTime.Now.AddYears(aniorestadesde).Year;
            var CantMayoresde60anios = (from o in db.PersonaConDiscapacidads where o.Persona.PersonaFechaNacimiento.Year <= FechaDesde && o.Eliminado == false select o).Count();
            aniorestadesde = 0;
            aniorestahasta = 0;

            var discapacitadomostrar = new ListadoPersonaConDiscapacidad
            {
                CantidadDePersonasDe45diasA17Anios = CantEdad45diasa17anios,
                CantidadDePersonasDe18aniosA59Anios = CantEdad18aniosa59anios,
                CantidadDePersonasMayoresA60anios = CantMayoresde60anios
            };

            JsonResult resultado = Json(discapacitadomostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }



        public JsonResult BuscarListadoDiscapacitados(int EdadFiltro, int EscuelaID, int LocalidadID, int FiltroCovid)
        {
            List<ListadoPersonaConDiscapacidad> discapacitadosmostrar = new List<ListadoPersonaConDiscapacidad>();

            var aniorestadesde = 0;
            var aniorestahasta = 0;
            var FechaDesde = DateTime.Now.AddYears(aniorestadesde).Year;
            var FechaHasta = DateTime.Now.AddYears(aniorestahasta).Year;

            var discapacitados = new List<PersonaConDiscapacidad>();

            if (EscuelaID > 0)
            {
                //BUSCAMOS EN LA TABLA QUE RELACIONA EL INSTITUTO CON LA PERSONA, EN BASE A UN INSTITUTO EN PARTICULAR
                var discapacitadosEscuelas = (from o in db.RelacioneInstitutoYPersonas where o.EscuelaID == EscuelaID select o).ToList();
                //RECORREMOS TODOS ESOS REGISTROS DE LA ESCUELA SELECCIONADA
                foreach (var discapacitadoEscuela in discapacitadosEscuelas)
                {
                    //POR CADA ESCUELA BUSCAMOS EN LA TABLA DE PERSONA CON DISCAPACIDAD EL REGISTRO QUE CORRESPONDE A CADA PERSONA DE ESA RELACION DE DISCAPACITADO ESCUELA
                    var personaConDiscapacidad = (from o in db.PersonaConDiscapacidads where o.PersonaID == discapacitadoEscuela.PersonaID && o.Eliminado == false select o).SingleOrDefault();
                    //SI EXISTE EL REGISTRO QUE RELACIONA LA PERSONA CON LA PERSONA CON DISCAPACIDAD 
                    if (personaConDiscapacidad != null)
                    {
                        //LA AGREGAMOS AL LISTADO VACIO DEL COMIENZO
                        discapacitados.Add(personaConDiscapacidad);
                    }
                }
            }
            else
            {
                discapacitados = (from o in db.PersonaConDiscapacidads where o.Eliminado == false select o).OrderBy(p => p.Persona.PersonaApellidoNombre).ToList();
            }
            if (LocalidadID > 0)
            {
                discapacitados = (from o in discapacitados where o.Persona.LocalidadesID == LocalidadID select o).ToList();
            }

            if (EdadFiltro == 1)
            {
                aniorestahasta = -17;
                FechaHasta = DateTime.Now.AddYears(aniorestahasta).Year;
                discapacitados = (from o in discapacitados
                                  where o.Persona.PersonaFechaNacimiento.Year >= FechaHasta
                                  select o).ToList();
            }

            if (EdadFiltro == 2)
            {
                aniorestadesde = -18;
                aniorestahasta = -59;
                FechaDesde = DateTime.Now.AddYears(aniorestadesde).Year;
                FechaHasta = DateTime.Now.AddYears(aniorestahasta).Year;
                discapacitados = (from o in discapacitados
                                  where o.Persona.PersonaFechaNacimiento.Year >= FechaHasta &&
                                  o.Persona.PersonaFechaNacimiento.Year <= FechaDesde
                                  select o).ToList();
            }

            if (EdadFiltro == 3)
            {
                aniorestadesde = -59;

                FechaDesde = DateTime.Now.AddYears(aniorestadesde).Year;
                discapacitados = (from o in discapacitados
                                  where o.Persona.PersonaFechaNacimiento.Year <= FechaDesde
                                  select o).ToList();
            }

             if (FiltroCovid == 1)
            {
                discapacitados = (from o in discapacitados where o.Persona.PersonaCovid == false select o).ToList();
            }

            if (FiltroCovid == 2)
            {
                discapacitados = (from o in discapacitados where o.Persona.PersonaCovid == true select o).ToList();
            }

            foreach (var discapacitado in discapacitados)
            {
                var diagnostico = discapacitado.Diagnostico;
                if (diagnostico == null)
                {
                    diagnostico = "";
                }
                var obrasocialCual = discapacitado.Persona.ObraSocialCual;
                if (obrasocialCual == null)
                {
                    obrasocialCual = "";
                }
                var personaDireccion = discapacitado.Persona.PersonaDireccion;
                if (personaDireccion == null)
                {
                    personaDireccion = "";
                }

                var Localidad = (from o in db.Personas where o.PersonaID == discapacitado.PersonaID select o.Localidad.LocalidadesNombre).Single();
                var personaMostrar = new ListadoPersonas
                {
                    PersonaID = discapacitado.PersonaID,
                    PersonaApellidoNombre = discapacitado.Persona.PersonaApellidoNombre.ToUpper(),
                    PersonaFechaNacimiento = discapacitado.Persona.PersonaFechaNacimiento,
                    PersonaLocalidadNombre = Localidad.ToUpper(),
                    PersonaDNI = discapacitado.Persona.PersonaDNI,
                    PersonaSexo = discapacitado.Persona.PersonaSexo,
                    PersonaDireccion = personaDireccion.ToUpper(),
                    PersonaTelefono = discapacitado.Persona.PersonaTelefono,
                    PersonaCovid = discapacitado.Persona.PersonaCovid,
                    ObraSocialCual = obrasocialCual.ToUpper(),
                    PersonaEdad = discapacitado.Persona.Edad
                };
                var discapacitadomostrar = new ListadoPersonaConDiscapacidad
                {
                    PersonaConDiscapacidadID = discapacitado.PersonaConDiscapacidadID,
                    Postrado = discapacitado.Postrado,
                    CudExistente= discapacitado.CudExistente,
                    NumeroCUD = discapacitado.NumeroCUD,
                    Diagnostico = diagnostico.ToUpper(),
                    Persona = personaMostrar
                };
                discapacitadosmostrar.Add(discapacitadomostrar);
            }
            JsonResult resultado = Json(discapacitadosmostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }


        public JsonResult BuscarDetalleDiscapacitado(int DiscapacitadoID)
        {
            var discapacitado = db.PersonaConDiscapacidads.Where(p => p.PersonaConDiscapacidadID == DiscapacitadoID).Single();

            var accesibilidadalserviciomostrar = new ListadoAccesibilidadAlServicio
            {
                AccesibilidadAlServicioID = discapacitado.AccesibilidadAlServicioID,
                AccesibilidadDescripcion = discapacitado.AccesibilidadAlServicio.AccesibilidadDescripcion
            };

            var tipodediscapacidadmostrar = new ListadoTipodeDiscapacidad
            {
                TipodeDiscapacidadID = discapacitado.TipodeDiscapacidadID,
                NombredelaDiscapacidad = discapacitado.TipodeDiscapacidad.NombredelaDiscapacidad
            };

            var personaMostrar = new ListadoPersonas
            {
                PersonaID = discapacitado.PersonaID,
                PersonaApellidoNombre = discapacitado.Persona.PersonaApellidoNombre,
                PersonaDireccion = discapacitado.Persona.PersonaDireccion,
                PersonaFechaNacimientoString = discapacitado.Persona.PersonaFechaNacimiento.ToString("dd/MM/yyyy"),
                PersonaDNI = discapacitado.Persona.PersonaDNI,
                PersonaTelefono = discapacitado.Persona.PersonaTelefono,
                PersonaObraSocial = discapacitado.Persona.PersonaObraSocial,
                ObraSocialCual = discapacitado.Persona.ObraSocialCual
            };

            var nivelEducativoDiscapacitadoString = (from o in db.NivelEducativoes where o.NivelEducativoID == discapacitado.NivelEducativoIDDiscapacitado select o.Niveles).Single();
            var nivelEducativoDiscapacitadoID = (from o in db.NivelEducativoes where o.NivelEducativoID == discapacitado.NivelEducativoIDDiscapacitado select o.NivelEducativoID).Single();
            var nivelEducativoConsultanteString = (from o in db.NivelEducativoes where o.NivelEducativoID == discapacitado.NivelEducativoIDConsultante select o.Niveles).Single();
            var nivelEducativoConsultanteID = (from o in db.NivelEducativoes where o.NivelEducativoID == discapacitado.NivelEducativoIDConsultante select o.NivelEducativoID).Single();

            var discapacitadomostrar = new ListadoPersonaConDiscapacidad
            {
                NumeroCUD = discapacitado.NumeroCUD,
                FechaInicioDiscapacidad = discapacitado.FechaInicioDiscapacidad.ToString("yyyy-MM-dd"),
                VencimientoCud = discapacitado.VencimientoCud.ToString("yyyy-MM-dd"),
                FechaNacimientoConsultante = discapacitado.FechaNacimientoConsultante.ToString("yyyy-MM-dd"),
                PersonaConDiscapacidadID = discapacitado.PersonaConDiscapacidadID,
                Diagnostico = discapacitado.Diagnostico,
                CudExistente = discapacitado.CudExistente,
                Postrado = discapacitado.Postrado,
                PencionPorincapacidad = discapacitado.PencionPorincapacidad,
                InicioDiscapacidadNacimiento = discapacitado.InicioDiscapacidadNacimiento,
                Observaciones = discapacitado.Observaciones,
                NombreConsultante = discapacitado.NombreConsultante,
                DireccionConsultante = discapacitado.DireccionConsultante,
                TelefonoConsultante = discapacitado.TelefonoConsultante,
                LocalidadConsultante = discapacitado.LocalidadConsultante,


                DiagnosticoEnfermedad = discapacitado.DiagnosticoEnfermedad,
                DetalleDiagnosticoEnfermedad = discapacitado.DetalleDiagnosticoEnfermedad,
                TratamientoMedico = discapacitado.TratamientoMedico,
                DetalleTratamientoMedico = discapacitado.DetalleTratamientoMedico,
                LugarTratamientoMedico = discapacitado.LugarTratamientoMedico,
                InterrumpioTratamientoMedico = discapacitado.InterrumpioTratamientoMedico,
                TiempoInterrupcionTratamientoMedico = discapacitado.TiempoInterrupcionTratamientoMedico,
                MotivoInterrupcionTratamientoMedico = discapacitado.MotivoInterrupcionTratamientoMedico,

                TrastornoSuenio = discapacitado.TrastornoSuenio,
                TrastornoAlimenticio = discapacitado.TrastornoAlimenticio,
                IngestaAnsioAntidepre = discapacitado.IngestaAnsioAntidepre,
                ConsumioAlcoholoDroga = discapacitado.ConsumioAlcoholoDroga,
                OtrosTrastornos = discapacitado.OtrosTrastornos,
                AbortoPorGolpe = discapacitado.AbortoPorGolpe,
                IntentoDeSuicidio = discapacitado.IntentoDeSuicidio,

                CuentaConParienteAQuienRecurir = discapacitado.CuentaConParienteAQuienRecurir,
                AQueParienteRecurir = discapacitado.AQueParienteRecurir,
                CuentaConAmigosVecinosCompanieroTrabajo = discapacitado.CuentaConAmigosVecinosCompanieroTrabajo,
                QueAmigosVecinosCompanieroTrabajo = discapacitado.QueAmigosVecinosCompanieroTrabajo,
                AsisteAIntitucionComunitaria = discapacitado.AsisteAIntitucionComunitaria,
                CualIntitucionComunitaria = discapacitado.CualIntitucionComunitaria,
                ConQuienSeContactaEnIntitucionComunitaria = discapacitado.ConQuienSeContactaEnIntitucionComunitaria,
                DejoDeContactarAAlguien = discapacitado.DejoDeContactarAAlguien,
                AQuienDejoDeContactar = discapacitado.AQuienDejoDeContactar,

                VioleciaFisicaOPiscConsultante = discapacitado.VioleciaFisicaOPiscConsultante,
                ViolacionAbusoSexualConsultante = discapacitado.ViolacionAbusoSexualConsultante,
                TestigoDeViolenciaConsultante = discapacitado.TestigoDeViolenciaConsultante,
                AbandonoConsultante = discapacitado.AbandonoConsultante,
                OtrasParejasConsultante = discapacitado.OtrasParejasConsultante,
                OtraViolenciaConsultante = discapacitado.OtraViolenciaConsultante,
                

                VioleciaFisicaOPiscDiscapacitado = discapacitado.VioleciaFisicaOPiscDiscapacitado,
                ViolacionAbusoSexualDiscapacitado = discapacitado.ViolacionAbusoSexualDiscapacitado,
                TestigoDeViolenciaDiscapacitado = discapacitado.TestigoDeViolenciaDiscapacitado,
                AbandonoDiscapacitado = discapacitado.AbandonoDiscapacitado,
                OtrasParejasDiscapacitado = discapacitado.OtrasParejasDiscapacitado,
                IgnoradoDiscapacitado = discapacitado.IgnoradoDiscapacitado,
                OtraViolenciaDiscapacitado = discapacitado.OtraViolenciaDiscapacitado,

                SituacionObreroConsultante = discapacitado.SituacionObreroConsultante,
                SituacionObreroDiscapacitado = discapacitado.SituacionObreroDiscapacitado,
                SituacionEmpresarioConsultante = discapacitado.SituacionEmpresarioConsultante,
                SituacionEmpresarioDiscapacitado = discapacitado.SituacionEmpresarioDiscapacitado,
                SituacionEmpleadoConsultante = discapacitado.SituacionEmpleadoConsultante,
                SituacionEmpleadoDiscapacitado = discapacitado.SituacionEmpleadoDiscapacitado,
                SituacionJubiladoConsultante = discapacitado.SituacionJubiladoConsultante,
                SituacionJubiladoDiscapacitado = discapacitado.SituacionJubiladoDiscapacitado,
                SituacionNoTrabajaConsultante = discapacitado.SituacionNoTrabajaConsultante,
                SituacionNoTrabajaDiscapacitado = discapacitado.SituacionNoTrabajaDiscapacitado,
                SituacionProfesionalConsultante = discapacitado.SituacionProfesionalConsultante,
                SituacionProfesionalDiscapacitado = discapacitado.SituacionProfesionalDiscapacitado,
                SituacionServicioDomesticoConsultante = discapacitado.SituacionServicioDomesticoConsultante,
                SituacionServicioDomesticoDiscapacitado = discapacitado.SituacionServicioDomesticoDiscapacitado,
                IngresosFamiliarLaboral = discapacitado.IngresosFamiliarLaboral,

                NivelEducativoConsultanteString = nivelEducativoConsultanteString,
                NivelEducativoDiscapacitadoString = nivelEducativoDiscapacitadoString,
                NivelEducativoIDConsultante = nivelEducativoConsultanteID,
                NivelEducativoIDDiscapacitado = nivelEducativoDiscapacitadoID,
                DniConsultante = discapacitado.DniConsultante,
                AccesibilidadAlServicio = accesibilidadalserviciomostrar,
                TipodeDiscapacidad = tipodediscapacidadmostrar,
                Persona = personaMostrar

            };



            JsonResult resultado = Json(discapacitadomostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult ValidacionDePersonaConDiscapacidadExistente(int PersonaID)
        {
            var personaID = (from o in db.PersonaConDiscapacidads where o.PersonaID == PersonaID && o.Eliminado == false select o).Count();
            var Validacion = true;
            if (personaID != 0)
            {
                Validacion = false;
            }
            return Json(Validacion);
        }


        public JsonResult SituacionHabitacionalDetalle(int PersonaCondiscapacidadID)
        {
            List<ListadoDeCaracteristicasSelecionadas> listadodecaracteristicasmostrar = new List<ListadoDeCaracteristicasSelecionadas>();

            var situacionesHabitacionales = (from o in db.TablaRelacionSitHabitYPersDiscapacidades where o.PersonaConDiscapacidadID == PersonaCondiscapacidadID select o.SituacionHabitacionalID).ToList();

            foreach (var situacionHabitacional in situacionesHabitacionales)
            {
                var observacioneContenidos = (from o in db.TablaRelacionSitHabitYPersDiscapacidades where o.SituacionHabitacionalID == situacionHabitacional && o.PersonaConDiscapacidadID == PersonaCondiscapacidadID select o.Observacion).FirstOrDefault();
                var caracteristicasSeleccionadas = (from o in db.SituacionHabitacional where o.SituacionHabitacionalID == situacionHabitacional select o.SectorViviendaID).Single();
                var observaciones = (from o in db.SituacionHabitacional where o.SituacionHabitacionalID == situacionHabitacional select o.Observacion).Single();
                
                var listadodecaracteristicas = new ListadoDeCaracteristicasSelecionadas
                {
                    SituacionHabitacionalID = situacionHabitacional,
                    SectorSeleccionado = caracteristicasSeleccionadas,
                    Observacion = observaciones,
                    ObservacionString = observacioneContenidos
                };
                listadodecaracteristicasmostrar.Add(listadodecaracteristicas);
            }

            JsonResult resultado = Json(listadodecaracteristicasmostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult BuscarPlantillaSituacionHabitacional()
        {
          List<VistaSituacionHabitacional> sectoresViviendaMostrar = new List<VistaSituacionHabitacional>();

            var situacionesHabitacionales = (from o in db.SituacionHabitacional select o).ToList();
            foreach (var situacionHabitacional in situacionesHabitacionales)
            {
                var caracteristicaMostrar = new VistaCaracteristicaSector
                {
                    SituacionHabitacionalID = situacionHabitacional.SituacionHabitacionalID,
                    CaracteristicaSectorID = situacionHabitacional.CaracteristicaSectorID,
                    NombreCaracteristicaSector = situacionHabitacional.CaracteristicaSector.NombreCaracteristicaSector,
                    Observacion = situacionHabitacional.Observacion
                };
                
                var sectorViviendaMostrar = sectoresViviendaMostrar.Find(s => s.SectorViviendaID == situacionHabitacional.SectorViviendaID);
                if (sectorViviendaMostrar == null)
                {
                    //VAMOS A CREAR EL REGISTRO EN EL LISTADO DE OBJETOS                 
                    sectorViviendaMostrar = new VistaSituacionHabitacional
                    {
                        SectorViviendaID = situacionHabitacional.SectorViviendaID,
                        NombreSectorVivienda = situacionHabitacional.SectorVivienda.NombreSectorVivienda,
                        Caracteristicas = new List<VistaCaracteristicaSector>()
                    };
                    sectoresViviendaMostrar.Add(sectorViviendaMostrar);
                }
                sectorViviendaMostrar.Caracteristicas.Add(caracteristicaMostrar);
            }
            

            JsonResult resultado = Json(sectoresViviendaMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult BuscarGrupoFamiliar(int PersonaID)
        {
            List<ListadoGrupoFamiliar> grupofamiliaresmostrar = new List<ListadoGrupoFamiliar>();
            var gruposFamiliares = (from o in db.GrupoFamiliars where o.PersonaID == PersonaID && o.Eliminado == false select o).ToList();
            foreach (var grupofamiliar in gruposFamiliares)
            {
                var grupoFamiliarSexoString = "MASCULINO";
                if (grupofamiliar.GrupoFamiliarSexo == Sexo.Femenino)
                {
                    grupoFamiliarSexoString = "FEMENINO";
                }
                if (grupofamiliar.GrupoFamiliarSexo == Sexo.Nobinario)
                {
                    grupoFamiliarSexoString = "NO BINARIO";
                }
                var grupofamiliarmostrar = new ListadoGrupoFamiliar
                {
                    GrupoFamiliarID = grupofamiliar.GrupoFamiliarID,
                    GrupoFamiliarApellidoNombre = grupofamiliar.GrupoFamiliarApellidoNombre.ToUpper(),
                    GrupoFamiliarDNI = grupofamiliar.GrupoFamiliarDNI,
                    GrupoFamiliarNacimientoString = grupofamiliar.GrupoFamiliarNacimiento.ToString("dd/MM/yyyy"),
                    GrupoFamiliarNacimiento = grupofamiliar.GrupoFamiliarNacimiento,
                    GrupoFamiliarSexo = grupofamiliar.GrupoFamiliarSexo,
                    GrupoFamiliarSexoString = grupoFamiliarSexoString,
                    GrupoFamiliarVinculo = grupofamiliar.GrupoFamiliarVinculo.ToUpper(),
                    GrupoFamiliarEscolaridad = grupofamiliar.GrupoFamiliarEscolaridad.ToUpper(),
                    GrupoFamiliarOcupacion = grupofamiliar.GrupoFamiliarOcupacion.ToUpper(),
                    GrupoFamiliarSalud = grupofamiliar.GrupoFamiliarSalud.ToUpper(),
                    GrupoFamiliarIngresos = grupofamiliar.GrupoFamiliarIngresos
                };
                grupofamiliaresmostrar.Add(grupofamiliarmostrar);
            }
            JsonResult resultado = Json(grupofamiliaresmostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult GuardarRelacionInstitutoYPersona(int PersonaID, int EscuelaID, int RelacionInstitutoYPersonaID, string NombreEscuela)
        {
            var existeEscuela = (from o in db.Escuelas where o.EscuelaNombre == NombreEscuela select o).Count();
            var seDuplicoEscuela = (from o in db.RelacioneInstitutoYPersonas where o.PersonaID == PersonaID && o.EscuelaID == EscuelaID select o).Count();
            int personaID = 0;
            if (existeEscuela != 0)
            {
                if (RelacionInstitutoYPersonaID == 0)
                {
                    if (seDuplicoEscuela == 0)
                    {
                        if (EscuelaID != 0)
                        {
                            var relacion = new RelacionInstitutoYPersona
                            {
                                PersonaID = PersonaID,
                                EscuelaID = EscuelaID
                            };
                            db.RelacioneInstitutoYPersonas.Add(relacion);
                            db.SaveChanges();
                            personaID = relacion.PersonaID;
                        }
                    }
                    else
                    {
                        personaID = -1;
                    }
                }
                else
                {
                    if (seDuplicoEscuela == 0)
                    {
                        RelacionInstitutoYPersona relacion = db.RelacioneInstitutoYPersonas.Find(RelacionInstitutoYPersonaID);
                        relacion.EscuelaID = EscuelaID;
                        db.SaveChanges();
                        personaID = PersonaID;
                    }
                    else
                    {
                        personaID = -1;
                    }
                }
            }
            return Json(personaID);
        }


        public JsonResult BuscarListadoEscuelaPorPersona(int PersonaID)
        {
            List<ListadoRelacionInstitutoYPersona> RelacionesInstitutoYPersonaMostrar = new List<ListadoRelacionInstitutoYPersona>();
            var relaciones = (from o in db.RelacioneInstitutoYPersonas where o.PersonaID == PersonaID select o).ToList();
            foreach (var relacion in relaciones)
            {
                var personamostrar = new ListadoPersonas
                {
                    PersonaID = relacion.PersonaID,
                    PersonaApellidoNombre = relacion.Persona.PersonaApellidoNombre.ToUpper()
                };
                var escuelaMostrar = new ListadoEscuela
                {
                    EscuelaID = relacion.EscuelaID,
                    EscuelaNombre = relacion.Escuela.EscuelaNombre.ToUpper()
                };
                var relacionInstitutoYPersonaMostrar = new ListadoRelacionInstitutoYPersona
                {
                    RelacionInstitutoYPersonaID = relacion.RelacionInstitutoYPersonaID,
                    Persona = personamostrar,
                    Escuela = escuelaMostrar
                };
                RelacionesInstitutoYPersonaMostrar.Add(relacionInstitutoYPersonaMostrar);
            }
            JsonResult resultado = Json(RelacionesInstitutoYPersonaMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult EditarRelacionInstitutoYPersona(int relacionInstitutoYPersonaID)
        {
            var relacionInstitutoYPersona = db.RelacioneInstitutoYPersonas.Where(p => p.RelacionInstitutoYPersonaID == relacionInstitutoYPersonaID).Single();

            var personamostrar = new ListadoPersonas
            {
                PersonaID = relacionInstitutoYPersona.PersonaID,
                PersonaApellidoNombre = relacionInstitutoYPersona.Persona.PersonaApellidoNombre.ToUpper()
            };
            var escuelaMostrar = new ListadoEscuela
            {
                EscuelaID = relacionInstitutoYPersona.EscuelaID,
                EscuelaNombre = relacionInstitutoYPersona.Escuela.EscuelaNombre.ToUpper()
            };
            var RelacionInstitutoYPersonaMostrar = new ListadoRelacionInstitutoYPersona
            {
                RelacionInstitutoYPersonaID = relacionInstitutoYPersona.RelacionInstitutoYPersonaID,
                Escuela = escuelaMostrar,
                Persona = personamostrar
            };

            return Json(RelacionInstitutoYPersonaMostrar);
        }


        public JsonResult EliminarRelacionEscuelaYPersona(int id)
        {
            RelacionInstitutoYPersona relacion = db.RelacioneInstitutoYPersonas.Find(id);
            db.RelacioneInstitutoYPersonas.Remove(relacion);
            db.SaveChanges();
            JsonResult resultado = Json(relacion, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        // GET: PersonaConDiscapacidads/Details/5
        public ActionResult Details(int? id)
        {
   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaConDiscapacidad personaConDiscapacidad = db.PersonaConDiscapacidads.Find(id);
            if (personaConDiscapacidad == null)
            {
                return HttpNotFound();
            }
            return View(personaConDiscapacidad);
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
            ViewBag.AccesibilidadAlServicioID = new SelectList(db.AccesibilidadAlServicios.OrderBy(p => p.AccesibilidadDescripcion).ToList(), "AccesibilidadAlServicioID", "AccesibilidadDescripcion");
            ViewBag.NivelEducativoIDConsultante = new SelectList(db.NivelEducativoes.OrderBy(p => p.Niveles).ToList(), "NivelEducativoID", "Niveles");
            ViewBag.NivelEducativoIDDiscapacitado = new SelectList(db.NivelEducativoes.OrderBy(p => p.Niveles).ToList(), "NivelEducativoID", "Niveles");
            ViewBag.TipodeDiscapacidadID = new SelectList(db.TipodeDiscapacidads.OrderBy(p => p.NombredelaDiscapacidad).ToList(), "TipodeDiscapacidadID", "NombredelaDiscapacidad");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaConDiscapacidad personaConDiscapacidad = db.PersonaConDiscapacidads.Find(id);
            if (personaConDiscapacidad == null)
            {
                return HttpNotFound();
            }
            return View(personaConDiscapacidad);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaConDiscapacidadID,Diagnostico,NumeroCUD,CudExistente,Postrado,PencionPorincapacidad," +
            "VencimientoCud,InicioDiscapacidadNacimiento,FechaInicioDiscapacidad,Observaciones,NombreConsultante,DireccionConsultante,LocalidadConsultante," +
            "TelefonoConsultante,DniConsultante,FechaNacimientoConsultante,DiagnosticoEnfermedad,DetalleDiagnosticoEnfermedad,TratamientoMedico," +
            "DetalleTratamientoMedico,LugarTratamientoMedico,InterrumpioTratamientoMedico,TiempoInterrupcionTratamientoMedico," +
            "MotivoInterrupcionTratamientoMedico,TrastornoSuenio,TrastornoAlimenticio,IngestaAnsioAntidepre,ConsumioAlcoholoDroga,OtrosTrastornos," +
            "AbortoPorGolpe,IntentoDeSuicidio,CuentaConParienteAQuienRecurir,AQueParienteRecurir,CuentaConAmigosVecinosCompanieroTrabajo," +
            "QueAmigosVecinosCompanieroTrabajo,AsisteAIntitucionComunitaria,CualIntitucionComunitaria,ConQuienSeContactaEnIntitucionComunitaria," +
            "DejoDeContactarAAlguien,AQuienDejoDeContactar,VioleciaFisicaOPiscConsultante,ViolacionAbusoSexualConsultante,TestigoDeViolenciaConsultante," +
            "AbandonoConsultante,OtrasParejasConsultante,OtraViolenciaConsultante,VioleciaFisicaOPiscDiscapacitado,ViolacionAbusoSexualDiscapacitado," +
            "TestigoDeViolenciaDiscapacitado,AbandonoDiscapacitado,OtrasParejasDiscapacitado,IgnoradoDiscapacitado,OtraViolenciaDiscapacitado," +
            "NivelEducativoIDConsultante,NivelEducativoIDDiscapacitado,IngresosFamiliarLaboral,SituacionObreroConsultante,SituacionEmpresarioConsultante," +
            "SituacionEmpleadoConsultante,SituacionJubiladoConsultante,SituacionServicioDomesticoConsultante,SituacionProfesionalConsultante," +
            "SituacionNoTrabajaConsultante,SituacionObreroDiscapacitado,SituacionEmpresarioDiscapacitado,SituacionEmpleadoDiscapacitado," +
            "SituacionJubiladoDiscapacitado,SituacionServicioDomesticoDiscapacitado,SituacionProfesionalDiscapacitado,SituacionNoTrabajaDiscapacitado,IngresosFamiliarLaboral," +
            "PersonaID,AccesibilidadAlServicioID,TipodeDiscapacidadID")] PersonaConDiscapacidad personaConDiscapacidad, int[] SectoresViviendasID)
        {
            //VALIDACION PARA QUE SE ELIJA UNA PERSONA
            if (personaConDiscapacidad.PersonaID > 0)
            {
                if (ModelState.IsValid)
                {
                    //HACER ESTA VALIDACION SI EL CAMPO NO ES REQUERIDO
                    if (!string.IsNullOrEmpty(personaConDiscapacidad.Diagnostico))
                    {
                        personaConDiscapacidad.Diagnostico = personaConDiscapacidad.Diagnostico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.Observaciones))
                    {
                        personaConDiscapacidad.Observaciones = personaConDiscapacidad.Observaciones.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.NombreConsultante))
                    {
                        personaConDiscapacidad.NombreConsultante = personaConDiscapacidad.NombreConsultante.ToUpper();
                    }
                    if (!string.IsNullOrEmpty(personaConDiscapacidad.DireccionConsultante))
                    {
                        personaConDiscapacidad.DireccionConsultante = personaConDiscapacidad.DireccionConsultante.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.LocalidadConsultante))
                    {
                        personaConDiscapacidad.LocalidadConsultante = personaConDiscapacidad.LocalidadConsultante.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.DetalleDiagnosticoEnfermedad))
                    {
                        personaConDiscapacidad.DetalleDiagnosticoEnfermedad = personaConDiscapacidad.DetalleDiagnosticoEnfermedad.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.DetalleTratamientoMedico))
                    {
                        personaConDiscapacidad.DetalleTratamientoMedico = personaConDiscapacidad.DetalleTratamientoMedico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.LugarTratamientoMedico))
                    {
                        personaConDiscapacidad.LugarTratamientoMedico = personaConDiscapacidad.LugarTratamientoMedico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.TiempoInterrupcionTratamientoMedico))
                    {
                        personaConDiscapacidad.TiempoInterrupcionTratamientoMedico = personaConDiscapacidad.TiempoInterrupcionTratamientoMedico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.MotivoInterrupcionTratamientoMedico))
                    {
                        personaConDiscapacidad.MotivoInterrupcionTratamientoMedico = personaConDiscapacidad.MotivoInterrupcionTratamientoMedico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.AQueParienteRecurir))
                    {
                        personaConDiscapacidad.AQueParienteRecurir = personaConDiscapacidad.AQueParienteRecurir.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.QueAmigosVecinosCompanieroTrabajo))
                    {
                        personaConDiscapacidad.QueAmigosVecinosCompanieroTrabajo = personaConDiscapacidad.QueAmigosVecinosCompanieroTrabajo.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.CualIntitucionComunitaria))
                    {
                        personaConDiscapacidad.CualIntitucionComunitaria = personaConDiscapacidad.CualIntitucionComunitaria.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.ConQuienSeContactaEnIntitucionComunitaria))
                    {
                        personaConDiscapacidad.ConQuienSeContactaEnIntitucionComunitaria = personaConDiscapacidad.ConQuienSeContactaEnIntitucionComunitaria.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.AQuienDejoDeContactar))
                    {
                        personaConDiscapacidad.AQuienDejoDeContactar = personaConDiscapacidad.AQuienDejoDeContactar.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.OtraViolenciaConsultante))
                    {
                        personaConDiscapacidad.OtraViolenciaConsultante = personaConDiscapacidad.OtraViolenciaConsultante.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.OtraViolenciaDiscapacitado))
                    {
                        personaConDiscapacidad.OtraViolenciaDiscapacitado = personaConDiscapacidad.OtraViolenciaDiscapacitado.ToUpper();
                    }

                    db.Entry(personaConDiscapacidad).State = EntityState.Modified;
                    db.SaveChanges();

                    if (SectoresViviendasID != null && SectoresViviendasID.Length > 0)
                    {
                        var ListadoDeTablaRelacionSitHabitYPersDiscapacidadID = (from o in db.TablaRelacionSitHabitYPersDiscapacidades where o.PersonaConDiscapacidadID == personaConDiscapacidad.PersonaConDiscapacidadID select o.TablaRelacionSitHabitYPersDiscapacidadID).ToList();
                        var numero = 0;
                        foreach (var TablaRelacionSitHabitYPersDiscapacidadID in ListadoDeTablaRelacionSitHabitYPersDiscapacidadID)
                        {
                
                            var sectorViviendaID = SectoresViviendasID[numero];
                            numero = numero + 1;
                            var situacionHabitacionalID = Convert.ToInt32(Request["Sector_" + sectorViviendaID]);

                            var observacionSectorVivienda = Request["Observacion_" + situacionHabitacionalID];


                            var situacionHabitacional = new TablaRelacionSitHabitYPersDiscapacidad
                            {
                                PersonaConDiscapacidadID = personaConDiscapacidad.PersonaConDiscapacidadID,
                                SituacionHabitacionalID = situacionHabitacionalID,
                                Observacion = observacionSectorVivienda,
                                TablaRelacionSitHabitYPersDiscapacidadID = TablaRelacionSitHabitYPersDiscapacidadID
                            };
                            db.Entry(situacionHabitacional).State = EntityState.Modified;
                            //db.TablaRelacionSitHabitYPersDiscapacidades.Add(situacionHabitacional);
                            db.SaveChanges();
                        }
                        numero = 0;
                    }
                    return RedirectToAction("Index");
                }

            }
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
            ViewBag.EscuelaID = new SelectList(db.Escuelas.OrderBy(p => p.EscuelaNombre).ToList(), "EscuelaID", "EscuelaNombre");
            ViewBag.AccesibilidadAlServicioID = new SelectList(db.AccesibilidadAlServicios.OrderBy(p => p.AccesibilidadDescripcion).ToList(), "AccesibilidadAlServicioID", "AccesibilidadDescripcion", personaConDiscapacidad.AccesibilidadAlServicioID);
            ViewBag.NivelEducativoIDConsultante = new SelectList(db.NivelEducativoes.OrderBy(p => p.Niveles).ToList(), "NivelEducativoID", "Niveles");
            ViewBag.NivelEducativoIDDiscapacitado = new SelectList(db.NivelEducativoes.OrderBy(p => p.Niveles).ToList(), "NivelEducativoID", "Niveles");
            ViewBag.TipodeDiscapacidadID = new SelectList(db.TipodeDiscapacidads.OrderBy(p => p.NombredelaDiscapacidad).ToList(), "TipodeDiscapacidadID", "NombredelaDiscapacidad", personaConDiscapacidad.TipodeDiscapacidadID);
            return View();
        }


        public ActionResult CargaDiscapacitado()
        {
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
            ViewBag.AccesibilidadAlServicioID = new SelectList(db.AccesibilidadAlServicios.OrderBy(p => p.AccesibilidadDescripcion).ToList(), "AccesibilidadAlServicioID", "AccesibilidadDescripcion");
            ViewBag.NivelEducativoIDConsultante = new SelectList(db.NivelEducativoes.OrderBy(p => p.Niveles).ToList(), "NivelEducativoID", "Niveles");
            ViewBag.NivelEducativoIDDiscapacitado = new SelectList(db.NivelEducativoes.OrderBy(p => p.Niveles).ToList(), "NivelEducativoID", "Niveles");
            ViewBag.TipodeDiscapacidadID = new SelectList(db.TipodeDiscapacidads.OrderBy(p => p.NombredelaDiscapacidad).ToList(), "TipodeDiscapacidadID", "NombredelaDiscapacidad");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CargaDiscapacitado([Bind(Include = "Diagnostico,NumeroCUD,CudExistente,Postrado,PencionPorincapacidad," +
            "VencimientoCud,InicioDiscapacidadNacimiento,FechaInicioDiscapacidad,Observaciones,NombreConsultante,DireccionConsultante,LocalidadConsultante," +
            "TelefonoConsultante,DniConsultante,FechaNacimientoConsultante,DiagnosticoEnfermedad,DetalleDiagnosticoEnfermedad,TratamientoMedico," +
            "DetalleTratamientoMedico,LugarTratamientoMedico,InterrumpioTratamientoMedico,TiempoInterrupcionTratamientoMedico," +
            "MotivoInterrupcionTratamientoMedico,TrastornoSuenio,TrastornoAlimenticio,IngestaAnsioAntidepre,ConsumioAlcoholoDroga,OtrosTrastornos," +
            "AbortoPorGolpe,IntentoDeSuicidio,CuentaConParienteAQuienRecurir,AQueParienteRecurir,CuentaConAmigosVecinosCompanieroTrabajo," +
            "QueAmigosVecinosCompanieroTrabajo,AsisteAIntitucionComunitaria,CualIntitucionComunitaria,ConQuienSeContactaEnIntitucionComunitaria," +
            "DejoDeContactarAAlguien,AQuienDejoDeContactar,VioleciaFisicaOPiscConsultante,ViolacionAbusoSexualConsultante,TestigoDeViolenciaConsultante," +
            "AbandonoConsultante,OtrasParejasConsultante,OtraViolenciaConsultante,VioleciaFisicaOPiscDiscapacitado,ViolacionAbusoSexualDiscapacitado," +
            "TestigoDeViolenciaDiscapacitado,AbandonoDiscapacitado,OtrasParejasDiscapacitado,IgnoradoDiscapacitado,OtraViolenciaDiscapacitado," +
            "NivelEducativoIDConsultante,NivelEducativoIDDiscapacitado,IngresosFamiliarLaboral,SituacionObreroConsultante,SituacionEmpresarioConsultante," +
            "SituacionEmpleadoConsultante,SituacionJubiladoConsultante,SituacionServicioDomesticoConsultante,SituacionProfesionalConsultante," +
            "SituacionNoTrabajaConsultante,SituacionObreroDiscapacitado,SituacionEmpresarioDiscapacitado,SituacionEmpleadoDiscapacitado," +
            "SituacionJubiladoDiscapacitado,SituacionServicioDomesticoDiscapacitado,SituacionProfesionalDiscapacitado,SituacionNoTrabajaDiscapacitado,IngresosFamiliarLaboral," +
            "PersonaID,AccesibilidadAlServicioID,TipodeDiscapacidadID")] PersonaConDiscapacidad personaConDiscapacidad, int[] SectoresViviendasID)
        {

            //VALIDACION PARA QUE SE ELIJA UNA PERSONA
            if (personaConDiscapacidad.PersonaID > 0)
            {   
                if (ModelState.IsValid)
                {
                    //HACER ESTA VALIDACION SI EL CAMPO NO ES REQUERIDO
                    if (!string.IsNullOrEmpty(personaConDiscapacidad.Diagnostico))
                    {
                        personaConDiscapacidad.Diagnostico = personaConDiscapacidad.Diagnostico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.Observaciones))
                    {
                        personaConDiscapacidad.Observaciones = personaConDiscapacidad.Observaciones.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.NombreConsultante))
                    {
                        personaConDiscapacidad.NombreConsultante = personaConDiscapacidad.NombreConsultante.ToUpper();
                    }
                    if (!string.IsNullOrEmpty(personaConDiscapacidad.DireccionConsultante))
                    {
                        personaConDiscapacidad.DireccionConsultante = personaConDiscapacidad.DireccionConsultante.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.LocalidadConsultante))
                    {
                        personaConDiscapacidad.LocalidadConsultante = personaConDiscapacidad.LocalidadConsultante.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.DetalleDiagnosticoEnfermedad))
                    {
                        personaConDiscapacidad.DetalleDiagnosticoEnfermedad = personaConDiscapacidad.DetalleDiagnosticoEnfermedad.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.DetalleTratamientoMedico))
                    {
                        personaConDiscapacidad.DetalleTratamientoMedico = personaConDiscapacidad.DetalleTratamientoMedico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.LugarTratamientoMedico))
                    {
                        personaConDiscapacidad.LugarTratamientoMedico = personaConDiscapacidad.LugarTratamientoMedico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.TiempoInterrupcionTratamientoMedico))
                    {
                        personaConDiscapacidad.TiempoInterrupcionTratamientoMedico = personaConDiscapacidad.TiempoInterrupcionTratamientoMedico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.MotivoInterrupcionTratamientoMedico))
                    {
                        personaConDiscapacidad.MotivoInterrupcionTratamientoMedico = personaConDiscapacidad.MotivoInterrupcionTratamientoMedico.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.AQueParienteRecurir))
                    {
                        personaConDiscapacidad.AQueParienteRecurir = personaConDiscapacidad.AQueParienteRecurir.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.QueAmigosVecinosCompanieroTrabajo))
                    {
                        personaConDiscapacidad.QueAmigosVecinosCompanieroTrabajo = personaConDiscapacidad.QueAmigosVecinosCompanieroTrabajo.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.CualIntitucionComunitaria))
                    {
                        personaConDiscapacidad.CualIntitucionComunitaria = personaConDiscapacidad.CualIntitucionComunitaria.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.ConQuienSeContactaEnIntitucionComunitaria))
                    {
                        personaConDiscapacidad.ConQuienSeContactaEnIntitucionComunitaria = personaConDiscapacidad.ConQuienSeContactaEnIntitucionComunitaria.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.AQuienDejoDeContactar))
                    {
                        personaConDiscapacidad.AQuienDejoDeContactar = personaConDiscapacidad.AQuienDejoDeContactar.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.OtraViolenciaConsultante))
                    {
                        personaConDiscapacidad.OtraViolenciaConsultante = personaConDiscapacidad.OtraViolenciaConsultante.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(personaConDiscapacidad.OtraViolenciaDiscapacitado))
                    {
                        personaConDiscapacidad.OtraViolenciaDiscapacitado = personaConDiscapacidad.OtraViolenciaDiscapacitado.ToUpper();
                    }

                    db.PersonaConDiscapacidads.Add(personaConDiscapacidad);
                    db.SaveChanges();

                    if (SectoresViviendasID != null && SectoresViviendasID.Length > 0)
                    {
                        for (int i = 0; i < SectoresViviendasID.Length; i++)
                        {
                            var sectorViviendaID = SectoresViviendasID[i];

                            var situacionHabitacionalID = Convert.ToInt32(Request["Sector_" + sectorViviendaID]);

                            var observacionSectorVivienda = Request["Observacion_" + situacionHabitacionalID];

                            var situacionHabitacional = new TablaRelacionSitHabitYPersDiscapacidad
                            {
                                PersonaConDiscapacidadID = personaConDiscapacidad.PersonaConDiscapacidadID,
                                SituacionHabitacionalID = situacionHabitacionalID,
                                Observacion = observacionSectorVivienda,
                            };
                            db.TablaRelacionSitHabitYPersDiscapacidades.Add(situacionHabitacional);
                            db.SaveChanges();
                        }
                    }
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
            ViewBag.EscuelaID = new SelectList(db.Escuelas.OrderBy(p => p.EscuelaNombre).ToList(), "EscuelaID", "EscuelaNombre");
            ViewBag.AccesibilidadAlServicioID = new SelectList(db.AccesibilidadAlServicios.OrderBy(p => p.AccesibilidadDescripcion).ToList(), "AccesibilidadAlServicioID", "AccesibilidadDescripcion", personaConDiscapacidad.AccesibilidadAlServicioID);
            ViewBag.NivelEducativoIDConsultante = new SelectList(db.NivelEducativoes.OrderBy(p => p.Niveles).ToList(), "NivelEducativoID", "Niveles");
            ViewBag.NivelEducativoIDDiscapacitado = new SelectList(db.NivelEducativoes.OrderBy(p => p.Niveles).ToList(), "NivelEducativoID", "Niveles");
            ViewBag.TipodeDiscapacidadID = new SelectList(db.TipodeDiscapacidads.OrderBy(p => p.NombredelaDiscapacidad).ToList(), "TipodeDiscapacidadID", "NombredelaDiscapacidad", personaConDiscapacidad.TipodeDiscapacidadID);
            return View();
        }


        public JsonResult EliminarPersonaConDiscapacidad(int id)
        {
            var personaID = (from o in db.PersonaConDiscapacidads where o.PersonaConDiscapacidadID == id select o.Persona.PersonaID).Single();
            var relacionInstitutoYPersona = (from o in db.RelacioneInstitutoYPersonas where o.PersonaID == personaID select o).Count();
            var Validacion = true;
            if (relacionInstitutoYPersona == 0)
            {
                PersonaConDiscapacidad personaConDiscapacidad = db.PersonaConDiscapacidads.Find(id);
                personaConDiscapacidad.Eliminado = true;
                db.SaveChanges();
            }
            else
            {
                Validacion = false;
            }
            return Json(Validacion);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
