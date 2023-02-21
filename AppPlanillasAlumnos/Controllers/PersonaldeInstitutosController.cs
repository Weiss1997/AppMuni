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
    public class PersonaldeInstitutosController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: PersonaldeInstitutos
        public ActionResult Index()
        {
            ViewBag.PersonaID = new SelectList(db.Personas.OrderBy(p => p.PersonaApellidoNombre).ToList(), "PersonaID", "PersonaApellidoNombre");
            ViewBag.EscuelaID = new SelectList(db.Escuelas.OrderBy(p => p.EscuelaNombre).ToList(), "EscuelaID", "EscuelaNombre");
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
            return View(db.PersonaldeInstitutos.ToList());

        }

        // GET: PersonaldeInstitutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaldeInstitutos personaldeInstitutos = db.PersonaldeInstitutos.Find(id);
            if (personaldeInstitutos == null)
            {
                return HttpNotFound();
            }
            return View(personaldeInstitutos);
        }

        public JsonResult BuscarListadoPersonal()
        {
            List<ListadoPersonalInstituto> listadopersonalIntitutoMostrar = new List<ListadoPersonalInstituto>();


            var personalLisadoCompleto = db.PersonaldeInstitutos.Include(p => p.Escuela).Include(p => p.Persona).Where(p => p.Eliminado == false).OrderBy(p => p.Persona.PersonaApellidoNombre).ToList();

            foreach (var personal in personalLisadoCompleto)
            {
                var personamostrar = new ListadoPersonas
                {
                    PersonaID = personal.PersonaID,
                    PersonaApellidoNombre = personal.Persona.PersonaApellidoNombre.ToUpper(),
                    PersonaDireccion = personal.Persona.PersonaDireccion.ToUpper(),
                    PersonaFechaNacimientoString = personal.Persona.PersonaFechaNacimiento.ToString("yyyy-MM-dd"),
                    PersonaObraSocial = personal.Persona.PersonaObraSocial,
                    ObraSocialCual = personal.Persona.ObraSocialCual.ToUpper(),
                    PersonaDNI = personal.Persona.PersonaDNI,
                    PersonaTelefono = personal.Persona.PersonaTelefono.ToUpper(),
                    PersonaEdad = personal.Persona.Edad
                };
                var escuelamostrar = new ListadoEscuela
                {
                    EscuelaID = personal.EscuelaID,
                    EscuelaNombre = personal.Escuela.EscuelaNombre.ToUpper(),
                    EscuelaTelefono = personal.Escuela.EscuelaTelefono,
                    Email = personal.Escuela.Email
                };
                var personalMostrar = new ListadoPersonalInstituto
                {
                    PersonaldeInstitutosID = personal.PersonaldeInstitutosID,
                    CargodentrodelaInstitucion = personal.CargodentrodelaInstitucion.ToUpper(),
                    Observaciones = personal.Observaciones.ToUpper(),
                    Persona = personamostrar,
                    Escuela = escuelamostrar
                };
                listadopersonalIntitutoMostrar.Add(personalMostrar);
            }

            JsonResult resultado = Json(listadopersonalIntitutoMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        //GUARDAR Y EDITAR
        public JsonResult GuardarPersonal(int PersonaID, int PersonaldeInstitutosID, string CargodentrodelaInstitucion, string Observaciones, int EscuelaID)
        {
            bool guardado = false;


            if (PersonaldeInstitutosID == 0)
            {
                var PersonaldelInstitutos = new PersonaldeInstitutos
                {
                    PersonaID = PersonaID,
                    CargodentrodelaInstitucion = CargodentrodelaInstitucion.ToUpper(),
                    Observaciones = Observaciones.ToUpper(),
                    EscuelaID = EscuelaID,

                };
                db.PersonaldeInstitutos.Add(PersonaldelInstitutos);
                db.SaveChanges();
                guardado = true;
            }
            else
            {
                PersonaldeInstitutos personaldeInstitutos = db.PersonaldeInstitutos.Find(PersonaldeInstitutosID);
                
                    personaldeInstitutos.PersonaldeInstitutosID = PersonaldeInstitutosID;
                    personaldeInstitutos.PersonaID = PersonaID;
                    personaldeInstitutos.CargodentrodelaInstitucion = CargodentrodelaInstitucion.ToUpper();
                    personaldeInstitutos.Observaciones = Observaciones.ToUpper();
                    personaldeInstitutos.EscuelaID = EscuelaID;
                    db.SaveChanges();
                    guardado = true;
                
            }

            JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        //BUSCAR LOS DATOS PARA EDITAR 
        public JsonResult BuscarDatosPersonal(int PersonaldeInstitutosID)
        {
            var personaldeInstitutos = db.PersonaldeInstitutos.Include(p => p.Escuela).Include(p => p.Persona).Where(p => p.PersonaldeInstitutosID == PersonaldeInstitutosID).Single();
            //var personaldeInstitutos = db.PersonaldeInstitutos.Where(p => p.PersonaldeInstitutosID == PersonaldeInstitutosID).Single();
            var personamostrar = new ListadoPersonas
            {
                PersonaID = personaldeInstitutos.PersonaID,
                PersonaApellidoNombre = personaldeInstitutos.Persona.PersonaApellidoNombre.ToUpper(),
                PersonaDireccion = personaldeInstitutos.Persona.PersonaDireccion.ToUpper(),
                PersonaFechaNacimientoString = personaldeInstitutos.Persona.PersonaFechaNacimiento.ToString("yyyy-MM-dd"),
                PersonaObraSocial = personaldeInstitutos.Persona.PersonaObraSocial,
                ObraSocialCual = personaldeInstitutos.Persona.ObraSocialCual.ToUpper(),
                PersonaDNI = personaldeInstitutos.Persona.PersonaDNI,
                PersonaTelefono = personaldeInstitutos.Persona.PersonaTelefono.ToUpper(),
                PersonaEdad = personaldeInstitutos.Persona.Edad
            };
            var escuelamostrar = new ListadoEscuela
            {
                EscuelaID = personaldeInstitutos.EscuelaID,
                EscuelaNombre = personaldeInstitutos.Escuela.EscuelaNombre.ToUpper(),
                EscuelaTelefono = personaldeInstitutos.Escuela.EscuelaTelefono,
                Email = personaldeInstitutos.Escuela.Email
            };
            var personalMostrar = new ListadoPersonalInstituto
            {
                PersonaldeInstitutosID = personaldeInstitutos.PersonaldeInstitutosID,
                CargodentrodelaInstitucion = personaldeInstitutos.CargodentrodelaInstitucion.ToUpper(),
                Observaciones = personaldeInstitutos.Observaciones.ToUpper(),
                Persona = personamostrar,
                Escuela = escuelamostrar
            };

            return Json(personalMostrar);
        }


        public JsonResult EliminarPersonal(int id)
        {

            PersonaldeInstitutos CargodentrodelaInstitucion = db.PersonaldeInstitutos.Find(id);
            CargodentrodelaInstitucion.Eliminado = true;
            db.SaveChanges();

            JsonResult resultado = Json(true, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return (resultado);
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
