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
    public class TrayectoriaEscolarsController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();
        private PacientesController PacientesController = new PacientesController();

        // GET: TrayectoriaEscolars
        public ActionResult Index()
        {
            var trayectoriaEscolars = db.TrayectoriaEscolars.Include(t => t.Escuelas).Include(t => t.Paciente);
            List<Paciente> pacientesMostrar = new List<Paciente>();
            PacientesController.ArmarComboPacientes(pacientesMostrar);
            ViewBag.PacienteID = new SelectList(pacientesMostrar.OrderBy(p => p.PersonaApellidoNombre).ToList(), "PacienteID", "PersonaApellidoNombre");
            ViewBag.EscuelaID = new SelectList(db.Escuelas.OrderBy(p => p.EscuelaNombre).ToList(), "EscuelaID", "EscuelaNombre");
            return View(trayectoriaEscolars.ToList());
        }

        public JsonResult BuscarListadoTrayectoriaE()
        {
            List<ListadoTrayectoriaEscolar> TrayectoriaEmostrar = new List<ListadoTrayectoriaEscolar>();
           
            var trayectoria = (from o in db.TrayectoriaEscolars where o.Eliminado == false select o).OrderBy(t=>t.Paciente.Persona.PersonaApellidoNombre).ToList();

            foreach (var trayectoriae in trayectoria)
            {
                var pacienteMostrar = new ListadoPacientes
                {
                    PacienteID = trayectoriae.PacienteID,
                    PersonaApellidoNombre = trayectoriae.Paciente.Persona.PersonaApellidoNombre.ToUpper(),
                };

                var escuelaMostrar = new ListadoEscuela
                {
                    EscuelaID = trayectoriae.EscuelaID,
                    EscuelaNombre = trayectoriae.Escuelas.EscuelaNombre.ToUpper(),
                };

                var trayectoriaEscolar = new ListadoTrayectoriaEscolar
                {
                    TrayectoriaEscolarID = trayectoriae.TrayectoriaEscolarID,
                    TrayectoriaEscolarDescripcion = trayectoriae.TrayectoriaEscolarDescripcion,
                    TrayectoriasFechaString = trayectoriae.TrayectoriasFecha.ToString("dd/MM/yyyy"),
                    Escuela = escuelaMostrar,
                    Paciente = pacienteMostrar
                };
                TrayectoriaEmostrar.Add(trayectoriaEscolar);
            }
            JsonResult resultado = Json(TrayectoriaEmostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult GuardarTrayectoriaEscolar(string TrayectoriaEscolarDescripcion, int PacienteID, int EscuelaID, int TrayectoriaEscolarID, DateTime TrayectoriasFecha)
        {
            bool guardado = false;

            if (TrayectoriaEscolarID == 0)
            {
                var PacienteExiste = (from o in db.TrayectoriaEscolars where o.PacienteID == PacienteID && o.Eliminado == false && o.EscuelaID == EscuelaID select o).Count();

                if (PacienteExiste == 0)
                {
                    var trayectoria = new TrayectoriaEscolar
                    {
                        TrayectoriaEscolarDescripcion = TrayectoriaEscolarDescripcion.ToUpper(),
                        TrayectoriasFecha = TrayectoriasFecha,
                        PacienteID = PacienteID,
                        EscuelaID = EscuelaID
                       
                    };
                    db.TrayectoriaEscolars.Add(trayectoria);
                    db.SaveChanges();
                    guardado = true;
                }
            }
            else
            {
                var PacienteExiste = (from o in db.TrayectoriaEscolars where o.PacienteID == PacienteID && o.TrayectoriaEscolarID == TrayectoriaEscolarID && o.Eliminado == false && o.EscuelaID == EscuelaID select o).Count();

                if(PacienteExiste > 0)
                {
                TrayectoriaEscolar trayectoria = db.TrayectoriaEscolars.Find(TrayectoriaEscolarID);
                trayectoria.TrayectoriaEscolarDescripcion = TrayectoriaEscolarDescripcion.ToUpper();
                trayectoria.TrayectoriasFecha = TrayectoriasFecha;
                //Comentado para un futuro//
                //trayectoria.PacienteID = PacienteID;
                //trayectoria.EscuelaID = EscuelaID;
                db.SaveChanges();
                guardado = true;
                }
            }
            JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult BuscarInfoTrayectoriaEscolar(int TrayectoriaEscolarID)
        {
            var trayectoriae = db.TrayectoriaEscolars.Where(p => p.TrayectoriaEscolarID == TrayectoriaEscolarID).Single();

            var pacienteMostrar = new ListadoPacientes
            {
                PacienteID = trayectoriae.PacienteID,
                PersonaApellidoNombre = trayectoriae.Paciente.Persona.PersonaApellidoNombre
            };

            var escuelaMostrar = new ListadoEscuela
            {
                EscuelaID = trayectoriae.EscuelaID,
                EscuelaNombre = trayectoriae.Escuelas.EscuelaNombre,
            };

            var trayectoriaEscolar = new ListadoTrayectoriaEscolar
            {
                TrayectoriaEscolarID = trayectoriae.TrayectoriaEscolarID,
                TrayectoriaEscolarDescripcion = trayectoriae.TrayectoriaEscolarDescripcion.ToUpper(),
                TrayectoriasFechaString = trayectoriae.TrayectoriasFecha.ToString("yyyy-MM-dd"),
                Escuela = escuelaMostrar,
                Paciente = pacienteMostrar
            };

            JsonResult resultado = Json(trayectoriaEscolar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;

        }
        
        public JsonResult EliminarTrayectoria(int id)
        {
            TrayectoriaEscolar trayectoriaEscolar = db.TrayectoriaEscolars.Find(id);
            trayectoriaEscolar.Eliminado = true;
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
