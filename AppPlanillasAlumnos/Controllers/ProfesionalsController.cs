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
    public class ProfesionalsController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: Profesionals
        public ActionResult Index()
        {
            var profesionals = db.Profesionals.Include(p => p.Especializacion).Include(p => p.Persona);
            ViewBag.EspecializacionID = new SelectList(db.Especializacions, "EspecializacionID", "EspecializacionNombre");
            return View(profesionals.ToList());
        }
        public JsonResult BuscarListadoProfesional()
        {
            List<ListadoProfesionales> profesionalesMostrar = new List<ListadoProfesionales>();

            var profesionales = (from o in db.Profesionals where o.Eliminado == false select o).OrderBy(p => p.Persona.PersonaApellidoNombre).ToList();

            foreach (var profesional in profesionales)
            {
                var especializacionesmostrar = new ListadoEspecializaciones
                {
                    EspecializacionID = profesional.EspecializacionID,
                    EspecializacionNombre = profesional.Especializacion.EspecializacionNombre.ToUpper()

                };
                var personaMostrar = new ListadoPersonas
                {
                    PersonaID = profesional.PersonaID,
                    PersonaApellidoNombre = profesional.Persona.PersonaApellidoNombre.ToUpper()
                };
                var profesionalMostrar = new ListadoProfesionales
                {
                    ProfesionalID = profesional.ProfesionalID,
                    ProfesionalMatricula = profesional.ProfesionalMatricula,
                    Persona = personaMostrar,
                    Especializaciones = especializacionesmostrar
                };
                profesionalesMostrar.Add(profesionalMostrar);
            }

            JsonResult resultado = Json(profesionalesMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult BuscarProfesional(string texto)
        {
            List<ListadoProfesionales> profesionalMostrar = new List<ListadoProfesionales>();

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.ToUpper();
            }
            if (texto.Length > 2)
            {
                var profesionalesEncontrados = db.Profesionals.Where(p => p.Persona.PersonaApellidoNombre.Contains(texto) && p.Eliminado == false )
                    .Take(100)
                    .ToList();
                foreach (var profesional in profesionalesEncontrados)
                {
                    var profesionalesMostrar = new ListadoProfesionales
                    {
                        ProfesionalID = profesional.ProfesionalID,
                        PersonaApellidoNombre = profesional.Persona.PersonaApellidoNombre.ToUpper()
                    };
                    profesionalMostrar.Add(profesionalesMostrar);
                }
                profesionalMostrar = profesionalMostrar.OrderBy(p => p.PersonaApellidoNombre).ToList();
            }
            return Json(profesionalMostrar);
        }

        public JsonResult GuardarProfesional(int PersonaID, int EspecializacionID, string ProfesionalMatricula, int ProfesionalID)
        {
            var MatriculaExistente = (from o in db.Profesionals where o.ProfesionalMatricula == ProfesionalMatricula && o.Eliminado == false select o).Count();
            var validacion = false;
            if (ProfesionalID == 0)
            {
                if (ProfesionalMatricula != "" && MatriculaExistente == 0)
                {
                    var profesional = new Profesional
                    {
                        PersonaID = PersonaID,
                        EspecializacionID = EspecializacionID,
                        ProfesionalMatricula = ProfesionalMatricula,
                    };
                    db.Profesionals.Add(profesional);
                    db.SaveChanges();
                    validacion = true;
                }
            }
            else
            {
                Profesional profesional = db.Profesionals.Find(ProfesionalID);
                if (ProfesionalMatricula != profesional.ProfesionalMatricula && MatriculaExistente == 0)
                {
                    profesional.ProfesionalMatricula = ProfesionalMatricula;
                    profesional.PersonaID = PersonaID;
                    profesional.EspecializacionID = EspecializacionID;
                    db.SaveChanges();
                    validacion = true;
                }
                else
                {
                    if (ProfesionalMatricula == profesional.ProfesionalMatricula)
                    {
                        profesional.ProfesionalMatricula = ProfesionalMatricula;
                        profesional.PersonaID = PersonaID;
                        profesional.EspecializacionID = EspecializacionID;
                        db.SaveChanges();
                        validacion = true;
                    } 
                }
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditarProfesional(int ProfesionalID)
        {
            var profesional = db.Profesionals.Where(p => p.ProfesionalID == ProfesionalID).Single();

            var personamostrar = new ListadoPersonas
            {
                PersonaID = profesional.PersonaID,
                PersonaApellidoNombre = profesional.Persona.PersonaApellidoNombre.ToUpper()
            };
            var especializacionmostrar = new ListadoEspecializaciones {
                EspecializacionID = profesional.EspecializacionID,
                EspecializacionNombre = profesional.Especializacion.EspecializacionNombre.ToUpper()
            };

            var profesionalesMostrar = new ListadoProfesionales
            {
                ProfesionalID = profesional.ProfesionalID,
                ProfesionalMatricula = profesional.ProfesionalMatricula,
                Persona = personamostrar,
                Especializaciones = especializacionmostrar
            };

            return Json(profesionalesMostrar);
        }
        public JsonResult ValidacionDeProfesionaExistente(string PersonaNombre)
        {
            var exiteNombrePersona = (from o in db.Personas where o.PersonaApellidoNombre == PersonaNombre && o.Eliminado == false select o).Count();
            var Validacion = true;
            if (exiteNombrePersona == 0)
            {
                Validacion = false;
            }
            return Json(Validacion);
        }




        public JsonResult BuscarPersonas(string texto)
        {
            List<ListadoPersonas> personasMostrar = new List<ListadoPersonas>();

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.ToUpper();
            }

            if (texto.Length > 2)
            {
                var personasEncontradas = db.Personas.Where(p => p.PersonaApellidoNombre.Contains(texto))
                    .OrderBy(p => p.PersonaApellidoNombre)
                    .Take(100)
                    .ToList();

                foreach (var persona in personasEncontradas)
                {
                    var personaMostrar = new ListadoPersonas
                    {
                        PersonaID = persona.PersonaID,
                        PersonaApellidoNombre = persona.PersonaApellidoNombre.ToUpper()
                    };
                    personasMostrar.Add(personaMostrar);
                }
            }

            //personasMostrar = personasMostrar.OrderBy(p => p.PersonaApellidoNombre).ToList();

            return Json(personasMostrar);
        }

        public JsonResult EliminarProfesional(int id)
        {
            var validacion = false;
            var tieneTratamiento = (from o in db.Tratamientos where o.ProfesionalID == id && o.Eliminado== false select o).Count();
            var tienePaciente = (from o in db.DatosDeAdmisions where o.ProfesionalID == id && o.Eliminado == false select o).Count();
            if (tieneTratamiento == 0 && tienePaciente == 0)
            {
                Profesional profesional = db.Profesionals.Find(id);
                profesional.Eliminado = true;
                db.SaveChanges();
                validacion = true;
            }
            return Json(validacion);
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
