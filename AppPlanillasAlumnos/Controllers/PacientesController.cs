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
    public class PacientesController : Controller
    {

        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: Pacientes
        public ActionResult Index()
        {
            ViewBag.PersonaID = new SelectList(db.Personas.OrderBy(p => p.PersonaApellidoNombre).ToList(), "PersonaID", "PersonaApellidoNombre");
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
           
            return View(db.Pacientes.ToList());
        }

        public JsonResult BuscarListadoPaciente()
        {
            List<ListadoPacientes> pacientesMostrar = new List<ListadoPacientes>();

            var paciente = (from o in db.Pacientes where o.Eliminado == false select o).OrderBy(p => p.Persona.PersonaApellidoNombre).ToList();

            foreach (var Paciente in paciente)
            {
                var pacienteMostrar = new ListadoPacientes
                {
                    PacienteID = Paciente.PacienteID,
                    PacienteCaracteristicas = Paciente.PacienteCaracteristicas,
                    PacienteControlEsfinter = Paciente.PacienteControlEsfinter,
                    PacienteDatosSignificativos = Paciente.PacienteDatosSignificativos,
                    PacienteEdadCaminar = Paciente.PacienteEdadCaminar,
                    PacienteLenguaje = Paciente.PacienteLenguaje,
                    PacienteLenguajeGestual = Paciente.PacienteLenguajeGestual,
                    PacienteLenguajeOral = Paciente.PacienteLenguajeOral,
                    PacienteIntelecto = Paciente.PacienteIntelecto,
                    PersonaID = Paciente.PersonaID,
                    PersonaApellidoNombre = Paciente.Persona.PersonaApellidoNombre.ToUpper(),

                };

                pacientesMostrar.Add(pacienteMostrar);
            }
            JsonResult resultado = Json(pacientesMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult GuardarPaciente(int PersonaID, string PacienteDatosSignificativos,
                  string PacienteCaracteristicas, int PacienteEdadCaminar,
                  string PacienteControlEsfinter, string PacienteLenguaje, string PacienteLenguajeGestual,
                  string PacienteLenguajeOral, string PacienteIntelecto, int PacienteID)

        {
            bool guardado = false;

            if (PacienteID == 0)
            {
                var PersonaExiste = (from o in db.Pacientes where o.PersonaID == PersonaID && o.Eliminado == false select o).Count();
                if (PersonaExiste == 0)
                {

                    var paciente = new Paciente
                    {
                        PersonaID = PersonaID,
                        PacienteDatosSignificativos = PacienteDatosSignificativos.ToUpper(),
                        PacienteCaracteristicas = PacienteCaracteristicas.ToUpper(),
                        PacienteEdadCaminar = PacienteEdadCaminar,
                        PacienteControlEsfinter = PacienteControlEsfinter.ToUpper(),
                        PacienteLenguaje = PacienteLenguaje.ToUpper(),
                        PacienteLenguajeGestual = PacienteLenguajeGestual.ToUpper(),
                        PacienteLenguajeOral = PacienteLenguajeOral.ToUpper(),
                        PacienteIntelecto = PacienteIntelecto.ToUpper()
                    };
                    db.Pacientes.Add(paciente);
                    db.SaveChanges();
                    guardado = true;
                }
            }
            else
            {
                var PersonaExiste = (from o in db.Pacientes where o.PersonaID == PersonaID && o.PacienteID == PacienteID && o.Eliminado == false select o).Count();
                if (PersonaExiste > 0)
                {
                    Paciente paciente = db.Pacientes.Find(PacienteID);
                    paciente.PacienteDatosSignificativos = PacienteDatosSignificativos.ToUpper();
                    paciente.PacienteCaracteristicas = PacienteCaracteristicas.ToUpper();
                    paciente.PacienteEdadCaminar = PacienteEdadCaminar;
                    paciente.PacienteControlEsfinter = PacienteControlEsfinter.ToUpper();
                    paciente.PacienteLenguaje = PacienteLenguaje.ToUpper();
                    paciente.PacienteLenguajeGestual = PacienteLenguajeGestual.ToUpper();
                    paciente.PacienteLenguajeOral = PacienteLenguajeOral.ToUpper();
                    paciente.PacienteIntelecto = PacienteIntelecto.ToUpper();
                    db.SaveChanges();
                    guardado = true;
                }

            }
            JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;

        }

        public JsonResult BuscarInfoEditarPaciente(int PacienteID)
        {
            var paciente = db.Pacientes.Where(p => p.PacienteID == PacienteID).Single();

            var pacienteMostrar = new ListadoPacientes
            {
                PacienteID = paciente.PacienteID,
                PacienteCaracteristicas = paciente.PacienteCaracteristicas.ToUpper(),
                PacienteControlEsfinter = paciente.PacienteControlEsfinter.ToUpper(),
                PacienteDatosSignificativos = paciente.PacienteDatosSignificativos.ToUpper(),
                PacienteEdadCaminar = paciente.PacienteEdadCaminar,
                PacienteIntelecto = paciente.PacienteIntelecto.ToUpper(),
                PacienteLenguaje = paciente.PacienteLenguaje.ToUpper(),
                PacienteLenguajeGestual = paciente.PacienteLenguajeGestual.ToUpper(),
                PacienteLenguajeOral = paciente.PacienteLenguajeOral.ToUpper(),
                PersonaID = paciente.PersonaID,
                PersonaApellidoNombre = paciente.Persona.PersonaApellidoNombre.ToUpper(),

            };

            JsonResult resultado = Json(pacienteMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;

        }
        public JsonResult BuscarPacientes(string texto)
        {
            List<ListadoPacientes> pacientesMostrar = new List<ListadoPacientes>();

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.ToUpper();
            }

            if (texto.Length > 2)
            {
                var pacientesEncontrados = db.Pacientes.Where(p => p.Persona.PersonaApellidoNombre.Contains(texto) && p.Eliminado == false)
                    .Take(100)
                    .ToList();

                foreach (var paciente in pacientesEncontrados)
                {
                    var pacienteMostrar = new ListadoPacientes
                    {
                        PacienteID = paciente.PacienteID,
                        PersonaApellidoNombre = paciente.Persona.PersonaApellidoNombre
                    };
                    pacientesMostrar.Add(pacienteMostrar);
                }

                pacientesMostrar = pacientesMostrar.OrderBy(p => p.PersonaApellidoNombre).ToList();
            }

            return Json(pacientesMostrar);
        }


        public JsonResult BuscarInfoPaciente(int PacienteID)
        {
            var paciente = db.Pacientes.Where(p => p.PacienteID == PacienteID).Single();

            var pacienteMostrar = new ListadoPacientes
            {
                PacienteID = paciente.PacienteID,
                PersonaApellidoNombre = paciente.Persona.PersonaApellidoNombre,
            };

            return Json(pacienteMostrar);
        }

        public JsonResult EliminarPaciente(int id)
        {
            var PacienteyTrayectoriaE = (from o in db.TrayectoriaEscolars where o.Eliminado == false &&  o.PacienteID == id select o).Count();
            var PacienteyTratamiento = (from o in db.Tratamientos where o.Eliminado == false && o.PacienteID == id select o).Count();
            var PacienteyAdmision = (from o in db.DatosDeAdmisions where o.Eliminado == false && o.PacienteID == id select o).Count();

            var validaciones = false;
        
            if (PacienteyTrayectoriaE == 0 && PacienteyTratamiento == 0 && PacienteyAdmision == 0)
            {
                Paciente paciente = db.Pacientes.Find(id);
                paciente.Eliminado = true;
                db.SaveChanges();
                validaciones = true;
            }

            return Json(validaciones);
        }

        public void ArmarComboPacientes(List<Paciente> pacientesMostrar)
        {
            var pacientes = db.Pacientes.ToList();
            foreach (var paciente in pacientes)
            {
                var pacienteMostrar = new Paciente
                {
                    PacienteID = paciente.PacienteID,
                    PersonaApellidoNombre = paciente.Persona.PersonaApellidoNombre
                };
                pacientesMostrar.Add(pacienteMostrar);
            }
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
