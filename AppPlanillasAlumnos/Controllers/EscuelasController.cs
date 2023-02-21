using AppPlanillasAlumnos.Data;
using AppPlanillasAlumnos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web;

namespace AppPlanillasAlumnos.Controllers
{
    [Authorize]
    public class EscuelasController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: Escuelas
        public ActionResult Index(int? ErrorEliminar)
        {
            if (ErrorEliminar == 1)
            {
                ViewBag.ErrorEliminar = "La Escuela esta en una Trayectoria escolar";
            }
            return View(db.Escuelas.ToList());
        }

        //Listado de datos //
        public JsonResult BuscarListadoEscuelas()
        {
            List<ListadoEscuela> escuelasMostrar = new List<ListadoEscuela>();

            var escuelas = (from o in db.Escuelas where o.Eliminado == false select o).OrderBy(e => e.EscuelaNombre).ToList();

            foreach (var Escuelas in escuelas)
            {
                var escuelaMostrar = new ListadoEscuela
                {
                    EscuelaID = Escuelas.EscuelaID,
                    EscuelaNombre = Escuelas.EscuelaNombre,
                    EscuelaTelefono = Escuelas.EscuelaTelefono,
                    EscuelaDireccion = Escuelas.EscuelaDireccion,
                    EscuelaPresidente = Escuelas.EscuelaPresidente,
                    Email = Escuelas.Email
                };
                escuelasMostrar.Add(escuelaMostrar);
            }
            JsonResult resultado = Json(escuelasMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult GuardarEscuela(int EscuelaID, string EscuelaNombre, string EscuelaPresidente, string Email, string EscuelaTelefono, string EscuelaDireccion)
        {
            bool guardado = false;

            if (EscuelaID == 0)
            {
                var EscuelaExiste = (from o in db.Escuelas where o.EscuelaNombre == EscuelaNombre && o.Eliminado == false select o).Count();
                if (EscuelaExiste == 0)
                {
                    var escuela = new Escuela
                    {
                        EscuelaNombre = EscuelaNombre.ToUpper(),
                        EscuelaPresidente = EscuelaPresidente.ToUpper(),
                        Email = Email.ToUpper(),
                        EscuelaTelefono = EscuelaTelefono.ToUpper(),
                        EscuelaDireccion = EscuelaDireccion.ToUpper(),
                    };
                    db.Escuelas.Add(escuela);
                    db.SaveChanges();
                    guardado = true;
                }
            }
            else
            {
                var EscuelaExiste = (from o in db.Escuelas where o.EscuelaNombre == EscuelaNombre && o.EscuelaID != EscuelaID && o.Eliminado == false select o).Count();

                if (EscuelaExiste == 0)
                {
                    Escuela escuela = db.Escuelas.Find(EscuelaID);
                    escuela.EscuelaNombre = EscuelaNombre.ToUpper();
                    escuela.EscuelaPresidente = EscuelaPresidente.ToUpper();
                    escuela.Email = Email.ToUpper();
                    escuela.EscuelaTelefono = EscuelaTelefono;
                    escuela.EscuelaDireccion = EscuelaDireccion.ToUpper();
                    db.SaveChanges();
                    guardado = true;
                }
            }
            JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }


        public JsonResult DatosEscolares(int EscuelaID)
        {
            var escuela = db.Escuelas.Where(p => p.EscuelaID == EscuelaID).Single();

            var escuelasmostrar = new ListadoEscuela
            {
                EscuelaID = escuela.EscuelaID,
                EscuelaNombre = escuela.EscuelaNombre.ToUpper(),
                EscuelaPresidente = escuela.EscuelaPresidente.ToUpper(),
                Email = escuela.Email.ToUpper(),
                EscuelaTelefono = escuela.EscuelaTelefono,
                EscuelaDireccion = escuela.EscuelaDireccion.ToUpper(),

            };
            return Json(escuelasmostrar);
        }

        public JsonResult BuscarInfoEscuela(int EscuelaID)
        {
            var escuela = db.Escuelas.Where(e => e.EscuelaID == EscuelaID).Single();

            var escuelaMostrar = new ListadoEscuela
            {
                EscuelaID = escuela.EscuelaID,
                EscuelaNombre = escuela.EscuelaNombre,
                EscuelaDireccion = escuela.EscuelaDireccion,
                EscuelaPresidente = escuela.EscuelaPresidente,
                EscuelaTelefono = escuela.EscuelaTelefono,
                Email = escuela.Email

            };

            return Json(escuelaMostrar);
        }

        public JsonResult BuscarEscuelas(string texto)
        {
            List<ListadoEscuela> escuelasMostrar = new List<ListadoEscuela>();

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.ToUpper();
            }

            if (texto.Length > 2)
            {
                var encontrandoEscuelas = db.Escuelas.Where(e => e.EscuelaNombre.Contains(texto) && e.Eliminado ==false).Take(100).ToList();

                foreach (var Escuela in encontrandoEscuelas)
                {
                    var escuela = new ListadoEscuela
                    {
                        EscuelaID = Escuela.EscuelaID,
                        EscuelaNombre = Escuela.EscuelaNombre
                    };
                    escuelasMostrar.Add(escuela);
                }

            }
            escuelasMostrar = escuelasMostrar.OrderBy(e => e.EscuelaNombre).ToList();

            return Json(escuelasMostrar);

        }


        public JsonResult EliminarEscuela(int id)
        {
            var EscuelayTrayectoria = (from o in db.TrayectoriaEscolars where o.Eliminado == false && o.EscuelaID == id select o).Count();
            var EscuelayDerivacion = (from o in db.Derivaciones where o.Eliminado == false && o.EscuelaID == id select o).Count();

            var validacion = false;

            if (EscuelayTrayectoria == 0 && EscuelayTrayectoria == 0)
            {
                Escuela escuela = db.Escuelas.Find(id);
                escuela.Eliminado = true;
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