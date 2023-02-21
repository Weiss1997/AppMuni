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

namespace AppPlanillasAlumnos.Controllers
{
    [Authorize]
    public class DerivacionesController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: Derivaciones
        public ActionResult Index()
        {
            var derivaciones = db.Derivaciones.Include(d => d.Persona).Include(d => d.Escuela);

            ViewBag.PersonaID = new SelectList(db.Personas.OrderBy(p => p.PersonaApellidoNombre).ToList(), "PersonaID", "PersonaApellidoNombre");
            ViewBag.EscuelaID = new SelectList(db.Escuelas.OrderBy(p => p.EscuelaNombre).ToList(), "EscuelaID", "EscuelaNombre");
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");

            return View(db.Derivaciones.ToList());       
        }

        //Mostrar datos en la tabla

        public JsonResult BuscarListadoDerivaciones(string Buscarfecha)
        {
            List<ListadoDerivaciones> derivacionesMostrar = new List<ListadoDerivaciones>();

            var derivaciones = (from o in db.Derivaciones where o.Eliminado == false select o).OrderBy(d=>d.Persona.PersonaApellidoNombre).ToList();

            DateTime FechaBuscar = new DateTime();
            if (!String.IsNullOrEmpty(Buscarfecha))
            {
                FechaBuscar = Convert.ToDateTime(Buscarfecha);
            }
            DateTime Fechapredeterminada = new DateTime(01/01/1920);
            if (FechaBuscar != null && FechaBuscar > Fechapredeterminada)
            {
                 derivaciones = (from o in derivaciones where o.DerivacionesFecha == FechaBuscar select o).ToList();
            }
            foreach (var derivacion in derivaciones)
            {   
                  var escuelamostrar = new ListadoEscuela
                  {
                      EscuelaID = derivacion.EscuelaID,
                      EscuelaNombre = derivacion.Escuela.EscuelaNombre.ToUpper(),
                      Email = derivacion.Escuela.Email
                  };
                  var personaMostrar = new ListadoPersonas
                  {
                      PersonaID = derivacion.PersonaID,
                      PersonaApellidoNombre = derivacion.Persona.PersonaApellidoNombre.ToUpper(),
                  };
                  var derivacionMostrar = new ListadoDerivaciones
                  {
                      DerivacionesID = derivacion.DerivacionesID,
                      DerivacionesFechaString = derivacion.DerivacionesFecha.ToString("dd/MM/yyyy"),
                      Persona = personaMostrar,
                      Escuela = escuelamostrar,
                  };
                     derivacionesMostrar.Add(derivacionMostrar);
            }

            JsonResult resultado = Json(derivacionesMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        //Guardar y editar 

        public JsonResult GuardarDerivacion(int DerivacionesID, DateTime DerivacionesFecha, DateTime DerivacionesAnioIngresoNivel, 
            DateTime DerivacionesAnioIngresoNivelActual, DateTime DerivacionesAnioIngresoInstitucionActual, string DerivacionesInstitucionAsistio,
            string DerivacionesDiferentesInstituaciones, bool DerivacionesRehizo, string DerivacionesSalaCurso,
            string DerivacionesObservaciones, bool DerivacionesRepitencia, string DerivacionesGradoAnioRepitencia,
            string DerivacionesMotivosRepitencia, bool DerivacionesInasistencias, string DerivacionesMotivosInasistencias,
            bool DerivacionesDesercion, string DerivacionesMotivosDesercion, bool DerivacionesAcompañamientoPedagogicoTerapeutico,
            string DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad, string DerivacionesSalaAsiste,
            string DerivacionesTurnoJornada, string DerivacionesMotivosSecundario, string DerivacionesFortalezasNinio,
            string DerivacionesDificultades, string DerivacionesEstrategiasResultados, bool DerivacionesAcompañamientoPedagogicoTerapeuticoActualmente,
            string DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidadActual, string DerivacionesNombreDocente,
            string DerivacionesAreaCurricular, string DerivacionesOtrosDocentesInformacion, int PersonaID, int EscuelaID, int DerivacionesNiveles)
        {
            bool guardado = false;

            if (DerivacionesID == 0)
            {
                var derivacion = new Derivaciones
                {
                    DerivacionesObservaciones = DerivacionesObservaciones.ToUpper(),
                    DerivacionesNiveles = DerivacionesNiveles,
                    DerivacionesAnioIngresoNivel = DerivacionesAnioIngresoNivel,
                    DerivacionesFecha = DerivacionesFecha,
                    DerivacionesAnioIngresoInstitucionActual = DerivacionesAnioIngresoInstitucionActual,
                    DerivacionesAnioIngresoNivelActual = DerivacionesAnioIngresoNivelActual,
                    DerivacionesInstitucionAsistio = DerivacionesInstitucionAsistio.ToUpper(),
                    DerivacionesDiferentesInstituaciones = DerivacionesDiferentesInstituaciones.ToUpper(),
                    DerivacionesRehizo = DerivacionesRehizo,
                    DerivacionesSalaCurso = DerivacionesSalaCurso.ToUpper(),
                    DerivacionesRepitencia = DerivacionesRepitencia,
                    DerivacionesGradoAnioRepitencia = DerivacionesGradoAnioRepitencia.ToUpper(),
                    DerivacionesMotivosRepitencia = DerivacionesMotivosRepitencia.ToUpper(),
                    DerivacionesInasistencias = DerivacionesInasistencias,
                    DerivacionesMotivosInasistencias = DerivacionesMotivosInasistencias.ToUpper(),
                    DerivacionesDesercion = DerivacionesDesercion,
                    DerivacionesMotivosDesercion = DerivacionesMotivosDesercion.ToUpper(),
                    DerivacionesAcompañamientoPedagogicoTerapeutico = DerivacionesAcompañamientoPedagogicoTerapeutico,
                    DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad = DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad.ToUpper(),
                    DerivacionesSalaAsiste = DerivacionesSalaAsiste.ToUpper(),
                    DerivacionesTurnoJornada = DerivacionesTurnoJornada.ToUpper(),
                    DerivacionesMotivosSecundario = DerivacionesMotivosSecundario.ToUpper(),
                    DerivacionesFortalezasNinio = DerivacionesFortalezasNinio.ToUpper(),
                    DerivacionesDificultades = DerivacionesDificultades.ToUpper(),
                    DerivacionesEstrategiasResultados = DerivacionesEstrategiasResultados.ToUpper(),
                    DerivacionesAcompañamientoPedagogicoTerapeuticoActualmente = DerivacionesAcompañamientoPedagogicoTerapeuticoActualmente,
                    DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidadActual = DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidadActual.ToUpper(),
                    DerivacionesNombreDocente = DerivacionesNombreDocente.ToUpper(),
                    DerivacionesAreaCurricular = DerivacionesAreaCurricular.ToUpper(),
                    DerivacionesOtrosDocentesInformacion = DerivacionesOtrosDocentesInformacion.ToUpper(),
                    PersonaID = PersonaID,
                    EscuelaID = EscuelaID
                };
                db.Derivaciones.Add(derivacion);
                db.SaveChanges();
                guardado = true;

            }
            else
            {
                Derivaciones derivaciones = db.Derivaciones.Find(DerivacionesID);
                {

                    derivaciones.DerivacionesID = DerivacionesID;
                    derivaciones.DerivacionesObservaciones = DerivacionesObservaciones.ToUpper();
                    derivaciones.DerivacionesNiveles = DerivacionesNiveles;
                    derivaciones.DerivacionesAnioIngresoNivel = DerivacionesAnioIngresoNivel;
                    derivaciones.DerivacionesFecha = DerivacionesFecha;
                    derivaciones.DerivacionesAnioIngresoInstitucionActual = DerivacionesAnioIngresoInstitucionActual;
                    derivaciones.DerivacionesAnioIngresoNivelActual = DerivacionesAnioIngresoNivelActual;
                    derivaciones.DerivacionesInstitucionAsistio = DerivacionesInstitucionAsistio.ToUpper();
                    derivaciones.DerivacionesDiferentesInstituaciones = DerivacionesDiferentesInstituaciones.ToUpper();
                    derivaciones.DerivacionesRehizo = DerivacionesRehizo;
                    derivaciones.DerivacionesSalaCurso = DerivacionesSalaCurso.ToUpper();
                    derivaciones.DerivacionesRepitencia = DerivacionesRepitencia;
                    derivaciones.DerivacionesGradoAnioRepitencia = DerivacionesGradoAnioRepitencia.ToUpper();
                    derivaciones.DerivacionesMotivosRepitencia = DerivacionesMotivosRepitencia.ToUpper();
                    derivaciones.DerivacionesInasistencias = DerivacionesInasistencias;
                    derivaciones.DerivacionesMotivosInasistencias = DerivacionesMotivosInasistencias.ToUpper();
                    derivaciones.DerivacionesDesercion = DerivacionesDesercion;
                    derivaciones.DerivacionesMotivosDesercion = DerivacionesMotivosDesercion.ToUpper();
                    derivaciones.DerivacionesAcompañamientoPedagogicoTerapeutico = DerivacionesAcompañamientoPedagogicoTerapeutico;
                    derivaciones.DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad = DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad.ToUpper();
                    derivaciones.DerivacionesSalaAsiste = DerivacionesSalaAsiste.ToUpper();
                    derivaciones.DerivacionesTurnoJornada = DerivacionesTurnoJornada.ToUpper();
                    derivaciones.DerivacionesMotivosSecundario = DerivacionesMotivosSecundario.ToUpper();
                    derivaciones.DerivacionesFortalezasNinio = DerivacionesFortalezasNinio.ToUpper();
                    derivaciones.DerivacionesDificultades = DerivacionesDificultades.ToUpper();
                    derivaciones.DerivacionesEstrategiasResultados = DerivacionesEstrategiasResultados.ToUpper();
                    derivaciones.DerivacionesAcompañamientoPedagogicoTerapeuticoActualmente = DerivacionesAcompañamientoPedagogicoTerapeuticoActualmente;
                    derivaciones.DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidadActual = DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidadActual.ToUpper();
                    derivaciones.DerivacionesNombreDocente = DerivacionesNombreDocente.ToUpper();
                    derivaciones.DerivacionesAreaCurricular = DerivacionesAreaCurricular.ToUpper();
                    derivaciones.DerivacionesOtrosDocentesInformacion = DerivacionesOtrosDocentesInformacion.ToUpper();
                    derivaciones.PersonaID = PersonaID;
                    derivaciones.EscuelaID = EscuelaID;
                    db.SaveChanges();
                    guardado = true;
                }
            }
                 
            JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
         }

        public JsonResult ValidacionDePersonaExistente(string PersonaNombre)
        {
            var exiteNombrePersona = (from o in db.Personas where o.PersonaApellidoNombre == PersonaNombre && o.Eliminado == false select o).Count();
            var Validacion = true;
            if (exiteNombrePersona == 0)
            {
                Validacion = false;
            }
            return Json(Validacion);
        }


        //public JsonResult ValidacionPersonaExiste(int PersonaID)
        //{
        //    var personaID = (from o in db.Derivaciones where o.PersonaID == PersonaID where o.Eliminado == false select o).Count();
        //    var Validacion = true;
        //    if (personaID != 0)
        //    {
        //        Validacion = false;
        //    }
        //    return Json(Validacion);
        //}

        //Buscar los datos para luego mostrarlos en el editar

        public JsonResult DatosDerivaciones(int DerivacionesID)
        {
            var derivaciones = db.Derivaciones.Where(d => d.DerivacionesID == DerivacionesID).Single();
            var personamostrar = new ListadoPersonas
            {
                PersonaID = derivaciones.PersonaID,
                PersonaApellidoNombre = derivaciones.Persona.PersonaApellidoNombre,
                PersonaDireccion = derivaciones.Persona.PersonaDireccion,
                PersonaFechaNacimientoString = derivaciones.Persona.PersonaFechaNacimiento.ToString("dd/MM/yyyy"),
                PersonaObraSocial = derivaciones.Persona.PersonaObraSocial,
                ObraSocialCual = derivaciones.Persona.ObraSocialCual,
                PersonaDNI = derivaciones.Persona.PersonaDNI,
                PersonaTelefono = derivaciones.Persona.PersonaTelefono,
                PersonaEdad = derivaciones.Persona.Edad
            };
            var escuelamostrar = new ListadoEscuela
            {
                EscuelaID = derivaciones.EscuelaID,
                EscuelaNombre = derivaciones.Escuela.EscuelaNombre,
                EscuelaTelefono = derivaciones.Escuela.EscuelaTelefono,
                Email = derivaciones.Escuela.Email
            };
            var derivacionmostrar = new ListadoDerivaciones
            {
                DerivacionesID = derivaciones.DerivacionesID,
                DerivacionesObservaciones = derivaciones.DerivacionesObservaciones,
                DerivacionesNiveles = derivaciones.DerivacionesNiveles,
                DerivacionesFechaString = derivaciones.DerivacionesFecha.ToString("yyyy-MM-dd"),
                DerivacionesAnioIngresoNivelString = derivaciones.DerivacionesAnioIngresoNivel.ToString("yyyy-MM-dd"),
                DerivacionesAnioIngresoInstitucionActualString = derivaciones.DerivacionesAnioIngresoInstitucionActual.ToString("yyyy-MM-dd"),
                DerivacionesAnioIngresoNivelActualString = derivaciones.DerivacionesAnioIngresoNivelActual.ToString("yyyy-MM-dd"),
                DerivacionesInstitucionAsistio = derivaciones.DerivacionesInstitucionAsistio,
                DerivacionesDiferentesInstituaciones = derivaciones.DerivacionesDiferentesInstituaciones,
                DerivacionesRehizo = derivaciones.DerivacionesRehizo,
                DerivacionesSalaCurso = derivaciones.DerivacionesSalaCurso,
                DerivacionesRepitencia = derivaciones.DerivacionesRepitencia,
                DerivacionesGradoAnioRepitencia = derivaciones.DerivacionesGradoAnioRepitencia,
                DerivacionesMotivosRepitencia = derivaciones.DerivacionesMotivosRepitencia,
                DerivacionesInasistencias = derivaciones.DerivacionesInasistencias,
                DerivacionesMotivosInasistencias = derivaciones.DerivacionesMotivosInasistencias,
                DerivacionesDesercion = derivaciones.DerivacionesDesercion,
                DerivacionesMotivosDesercion = derivaciones.DerivacionesMotivosDesercion,
                DerivacionesAcompañamientoPedagogicoTerapeutico = derivaciones.DerivacionesAcompañamientoPedagogicoTerapeutico,
                DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad = derivaciones.DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad,
                DerivacionesSalaAsiste = derivaciones.DerivacionesSalaAsiste,
                DerivacionesTurnoJornada = derivaciones.DerivacionesTurnoJornada,
                DerivacionesMotivosSecundario = derivaciones.DerivacionesMotivosSecundario,
                DerivacionesFortalezasNinio = derivaciones.DerivacionesFortalezasNinio,
                DerivacionesDificultades = derivaciones.DerivacionesDificultades,
                DerivacionesEstrategiasResultados = derivaciones.DerivacionesEstrategiasResultados,
                DerivacionesAcompañamientoPedagogicoTerapeuticoActualmente = derivaciones.DerivacionesAcompañamientoPedagogicoTerapeuticoActualmente,
                DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidadActual = derivaciones.DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidadActual,
                DerivacionesNombreDocente = derivaciones.DerivacionesNombreDocente,
                DerivacionesAreaCurricular = derivaciones.DerivacionesAreaCurricular,
                DerivacionesOtrosDocentesInformacion = derivaciones.DerivacionesOtrosDocentesInformacion,
                Persona = personamostrar,
                Escuela = escuelamostrar
            };

            return Json(derivacionmostrar);
        }

        //Detalle

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Derivaciones derivaciones = db.Derivaciones.Find(id);
            if (derivaciones == null)
            {
                return HttpNotFound();
            }
            return View(derivaciones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "DerivacionesID,DerivacionesFecha,DerivacionesIngresoNivel,DerivacionesSalaCurso,DerivacionesDescripciones,DerivacionesMotivos,DerivacionesAcompañamientoPedagogicoTerapeuticoTiempoModalidad,DerivacionesInstitucionAsistio,DerivacionesAnioIngresoInstitucionActual,DerivacionesTurnoJornada,DerivacionesFortalezasNinio,DerivacionesDificultades,DerivacionesEstrategiasResultados,DerivacionesNombreDocente,DerivacionesAreaCurricular,DerivacionesOtrosDocentesInformacion")] Derivaciones derivaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(derivaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(derivaciones);
        }

       

        public JsonResult EliminarDerivacion(int id)
        {  
            Derivaciones derivaciones = db.Derivaciones.Find(id);
            derivaciones.Eliminado = true;
            db.SaveChanges();
            return Json(true);
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
