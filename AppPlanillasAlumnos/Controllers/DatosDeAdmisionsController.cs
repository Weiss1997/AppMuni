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
    public class DatosDeAdmisionsController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: DatosDeAdmisions
        public ActionResult Index()
        {
            var datosAdmision = db.DatosDeAdmisions.Include(a => a.Paciente);

            ViewBag.ProfesionalID = new SelectList(db.Personas.OrderBy(p => p.PersonaApellidoNombre).ToList(), "ProfesionalID", "PersonaApellidoNombre");


            return View(db.DatosDeAdmisions.ToList());
        }

        public JsonResult GuardarDatoAdmision(int FichaAdmisionID, DateTime FichaAdmisionFecha,
            string FichaAdmisionParentesco, int ProfesionalID,
            string FichaAdmisionDescripcion, string FichaAdmisionServicio,
            string FichaAdmisionRelacion, string FichaAdmisionObservacion, int PacienteID)
        {
            bool guardado = false;

            if (FichaAdmisionID == 0)
            {
                var fichasAdmicionPaciente = (from o in db.DatosDeAdmisions where o.PacienteID == PacienteID && o.Eliminado == false select o).Count();
                if (fichasAdmicionPaciente == 0)
                {
                    var datosAdmision = new DatosDeAdmision
                    {
                        FichaAdmisionFecha = FichaAdmisionFecha,
                        FichaAdmisionParentesco = FichaAdmisionParentesco.ToUpper(),
                        FichaAdmisionDescripcion = FichaAdmisionDescripcion.ToUpper(),
                        FichaAdmisionServicio = FichaAdmisionServicio.ToUpper(),
                        FichaAdmisionRelacion = FichaAdmisionRelacion.ToUpper(),
                        FichaAdmisionObservacion = FichaAdmisionObservacion.ToUpper(),
                        ProfesionalID = ProfesionalID,
                        PacienteID = PacienteID
                    };
                    db.DatosDeAdmisions.Add(datosAdmision);
                    db.SaveChanges();

                    guardado = true;
                }
            }
            else
            {
                DatosDeAdmision datosDeAdmision = db.DatosDeAdmisions.Find(FichaAdmisionID);
                if (FichaAdmisionDescripcion != "")
                {
                    var fichasAdmicionPaciente = (from o in db.DatosDeAdmisions where o.PacienteID == PacienteID && o.Eliminado == false && o.FichaAdmisionID != FichaAdmisionID select o).Count();
                    if (fichasAdmicionPaciente == 0)
                    {
                        datosDeAdmision.FichaAdmisionFecha = FichaAdmisionFecha;
                        datosDeAdmision.FichaAdmisionParentesco = FichaAdmisionParentesco.ToUpper();
                        datosDeAdmision.FichaAdmisionDescripcion = FichaAdmisionDescripcion.ToUpper();
                        datosDeAdmision.FichaAdmisionServicio = FichaAdmisionServicio.ToUpper();
                        datosDeAdmision.FichaAdmisionRelacion = FichaAdmisionRelacion.ToUpper();
                        datosDeAdmision.FichaAdmisionObservacion = FichaAdmisionObservacion.ToUpper();
                        datosDeAdmision.ProfesionalID = ProfesionalID;
                        datosDeAdmision.PacienteID = PacienteID;
                        db.SaveChanges();

                        guardado = true;
                    }                    
                }

            };

            return Json(guardado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BuscarListadoDatosAdmision()
        {
            List<ListadoDatosAdmision> datosAdmisionMostrar = new List<ListadoDatosAdmision>();

            var datosDeAdmision = (from o in db.DatosDeAdmisions where o.Eliminado == false select o).OrderBy(p=>p.Paciente.Persona.PersonaApellidoNombre).ToList();


            foreach (var datoAdmision in datosDeAdmision)
            {
                var profesional = (from o in db.Profesionals where o.ProfesionalID == datoAdmision.ProfesionalID select o).Single();

                var profesionalMostrar = new ListadoProfesionales
                {
                    ProfesionalID = datoAdmision.ProfesionalID,
                    PersonaApellidoNombre = profesional.Persona.PersonaApellidoNombre.ToUpper(),
                };

                var datoAdmisionMostrar = new ListadoDatosAdmision
                {
                    FichaAdmisionID = datoAdmision.FichaAdmisionID,
                    FichaAdmisionParentesco = datoAdmision.FichaAdmisionParentesco.ToUpper(),
                    FichaAdmisionFechaString = datoAdmision.FichaAdmisionFecha.ToString("dd/MM/yyyy"),                   
                    FichaAdmisionDescripcion = datoAdmision.FichaAdmisionDescripcion.ToUpper(),
                    FichaAdmisionServicio = datoAdmision.FichaAdmisionServicio.ToUpper(),
                    FichaAdmisionRelacion = datoAdmision.FichaAdmisionRelacion.ToUpper(),
                    FichaAdmisionObservacion = datoAdmision.FichaAdmisionObservacion.ToUpper(),
                    Profesionales = profesionalMostrar,
                    PacienteID = datoAdmision.PacienteID,
                    PacienteNombre = datoAdmision.Paciente.Persona.PersonaApellidoNombre.ToUpper(),
                };
                datosAdmisionMostrar.Add(datoAdmisionMostrar);
            }

            return Json(datosAdmisionMostrar, JsonRequestBehavior.AllowGet);

        }

        public JsonResult BuscarInfoDeAdmision(int FichaAdmisionID)
        {
            var datoAdmision = db.DatosDeAdmisions.Where(d => d.FichaAdmisionID == FichaAdmisionID).Single();
            var profesional = (from o in db.Profesionals where o.ProfesionalID == datoAdmision.ProfesionalID select o).Single();

            var profesionalMostrar = new ListadoProfesionales
            {
                ProfesionalID = datoAdmision.ProfesionalID,
                PersonaApellidoNombre = profesional.Persona.PersonaApellidoNombre,
            };
            var datoAdmisionMostrar = new ListadoDatosAdmision
            {
                FichaAdmisionID = datoAdmision.FichaAdmisionID,
                FichaAdmisionFechaString = datoAdmision.FichaAdmisionFecha.ToString("yyyy-MM-dd"),
                FichaAdmisionParentesco = datoAdmision.FichaAdmisionParentesco,
                FichaAdmisionDescripcion = datoAdmision.FichaAdmisionDescripcion,
                FichaAdmisionServicio = datoAdmision.FichaAdmisionServicio,
                FichaAdmisionRelacion = datoAdmision.FichaAdmisionRelacion,
                FichaAdmisionObservacion = datoAdmision.FichaAdmisionObservacion,
                Profesionales = profesionalMostrar,
                PacienteID = datoAdmision.PacienteID,
                PacienteNombre = datoAdmision.Paciente.Persona.PersonaApellidoNombre,
            };

            return Json(datoAdmisionMostrar);
        }

        public JsonResult ValidacionPacienteExiste(int PacienteID)
        {
            var fichasAdmicionPaciente = (from o in db.DatosDeAdmisions where o.PacienteID == PacienteID && o.Eliminado == false select o).Count();
            var validacion = true;
            if (fichasAdmicionPaciente > 0)
            {
                //QUIERE DECIR QUE ESE PACIENTE TIENE UNA DERIVACION
                validacion = false;
            }
            return Json(validacion);
        }

        public JsonResult EliminarDatosDeAdmision(int id)
        {
            DatosDeAdmision datosDeAdmision = db.DatosDeAdmisions.Find(id);
            datosDeAdmision.Eliminado = true;
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
