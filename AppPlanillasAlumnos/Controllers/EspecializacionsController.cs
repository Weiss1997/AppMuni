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
    public class EspecializacionsController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: Especializacions
        public ActionResult Index()
        {      
            return View(db.Especializacions.ToList());
        }
        public JsonResult BuscarListadoEspecializaciones()
        {
            List<ListadoEspecializaciones> especializacionesmostrar = new List<ListadoEspecializaciones>();


            var especializaciones = (from o in db.Especializacions where o.Eliminado == false select o).OrderBy(p => p.EspecializacionNombre).ToList();

            foreach (var especializacion in especializaciones)
            {
                var especializacionmostrar = new ListadoEspecializaciones
                {
                    EspecializacionID = especializacion.EspecializacionID,
                    EspecializacionNombre = especializacion.EspecializacionNombre.ToUpper()
                };
                especializacionesmostrar.Add(especializacionmostrar);
            }

            JsonResult resultado = Json(especializacionesmostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult GuardarEspecializacion(string EspecializacionNombre, int EspecializacionID)
        {
            bool validacion = false;
            var nombreEspecializacionExiste = (from o in db.Especializacions where o.EspecializacionNombre == EspecializacionNombre && o.Eliminado==false select o).Count();
            if (nombreEspecializacionExiste == 0)
            {
                if (EspecializacionID == 0)
                {
                    var especializacion = new Especializacion
                    {
                        EspecializacionNombre = EspecializacionNombre.ToUpper()
                    };
                    db.Especializacions.Add(especializacion);
                    db.SaveChanges();

                    validacion = true;
                }
                else
                {
                    Especializacion especializacion = db.Especializacions.Find(EspecializacionID);
                    especializacion.EspecializacionNombre = EspecializacionNombre.ToUpper();
                    db.SaveChanges();
                    validacion = true;
                }
            }        
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditarEspecializacion(int EspecializacionID)
        {
            var especializacion = db.Especializacions.Where(p => p.EspecializacionID == EspecializacionID).Single();           
            var especializacionmostrar = new ListadoEspecializaciones
            {
                EspecializacionID = especializacion.EspecializacionID,
                EspecializacionNombre = especializacion.EspecializacionNombre.ToUpper()
        };
            return Json(especializacionmostrar);
        }

        public JsonResult EliminarEspecializacion(int EspecializacionID)
        {
            var validacion = false;
            var esProfesional = (from o in db.Profesionals where o.EspecializacionID == EspecializacionID select o).Count();
            if (esProfesional == 0)
            {
                Especializacion especializacion = db.Especializacions.Find(EspecializacionID);
                especializacion.Eliminado = true;
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
