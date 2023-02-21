using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppPlanillasAlumnos.Data;
using AppPlanillasAlumnos.Models.SeguimientoInfantil;

namespace AppPlanillasAlumnos.Controllers
{
    [Authorize]
    public class PreguntasIodisController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: PreguntasIodis
        public ActionResult Index()
        {
            return View(db.PreguntasIodis.ToList());
        }

        public JsonResult GuardarPreguntaIodi(int PreguntaIodiID, string PreguntasIodiDescripcion, int PreguntasIodiEdadID, int PreguntasIodiclasificacionID)
        {
            bool guardado = false;

            if (PreguntaIodiID == 0)
            {
                if (PreguntasIodiDescripcion != "")
                {
                    var preguntasIodi = new PreguntasIodi
                    {
                        PreguntasIodiDescripcion = PreguntasIodiDescripcion,
                        PreguntasIodiEdadID = PreguntasIodiEdadID,
                        PreguntasIodiclasificacionID = PreguntasIodiclasificacionID

                    };
                    db.PreguntasIodis.Add(preguntasIodi);
                    db.SaveChanges();

                    guardado = true;
                }
            }
            else
            {
                PreguntasIodi preguntasIodi = db.PreguntasIodis.Find(PreguntaIodiID);
                if (PreguntasIodiDescripcion != "")
                {
                    preguntasIodi.PreguntasIodiDescripcion = PreguntasIodiDescripcion;
                    preguntasIodi.PreguntasIodiEdadID = PreguntasIodiEdadID;
                    preguntasIodi.PreguntasIodiclasificacionID = PreguntasIodiclasificacionID;
                    db.SaveChanges();

                    guardado = true;
                };
            }
            return Json(guardado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarListadoPreguntasIodi()
        {
            List<ListadoPreguntasIodi> preguntasIodiMostrar = new List<ListadoPreguntasIodi>();

            var PreguntasIodi = db.PreguntasIodis.Where(p => p.Eliminado == false).ToList();

            foreach (var preguntaIodi in PreguntasIodi)
            {
                var preguntasIodiEdadDescripcion = "Todos";
                if (preguntaIodi.PreguntasIodiEdadID == 2)
                {
                    preguntasIodiEdadDescripcion = "1°T";
                }
                if (preguntaIodi.PreguntasIodiEdadID == 3)
                {
                    preguntasIodiEdadDescripcion = "2°T";
                }
                if (preguntaIodi.PreguntasIodiEdadID == 4)
                {
                    preguntasIodiEdadDescripcion = "3°T";
                }
                if (preguntaIodi.PreguntasIodiEdadID == 5)
                {
                    preguntasIodiEdadDescripcion = "4°T";
                }
                if (preguntaIodi.PreguntasIodiEdadID == 6)
                {
                    preguntasIodiEdadDescripcion = "1 año";
                }
                if (preguntaIodi.PreguntasIodiEdadID == 7)
                {
                    preguntasIodiEdadDescripcion = "2 años";
                }
                if (preguntaIodi.PreguntasIodiEdadID == 8)
                {
                    preguntasIodiEdadDescripcion = "3 años";
                }

                var preguntasIodiclasificacion = "M";
                if(preguntaIodi.PreguntasIodiclasificacionID == 2)
                {
                    preguntasIodiclasificacion = "C";
                }
                if (preguntaIodi.PreguntasIodiclasificacionID == 3)
                {
                    preguntasIodiclasificacion = "SE";
                }
                if (preguntaIodi.PreguntasIodiclasificacionID == 4)
                {
                    preguntasIodiclasificacion = "CVMC";
                }

                var preguntaIodiMostrar = new ListadoPreguntasIodi
                {
                    PreguntasIodiID = preguntaIodi.PreguntasIodiID,
                    PreguntasIodiDescripcion = preguntaIodi.PreguntasIodiDescripcion,
                    PreguntasIodiEdadID = preguntaIodi.PreguntasIodiEdadID,
                    PreguntasIodiEdadDescripcion = preguntasIodiEdadDescripcion.ToString(),
                    PreguntasIodiclasificacionID = preguntaIodi.PreguntasIodiclasificacionID,
                    PreguntasIodiclasificacion = preguntasIodiclasificacion.ToString(),
                };
                preguntasIodiMostrar.Add(preguntaIodiMostrar);
            }

            return Json(preguntasIodiMostrar, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BuscarInfoPreguntaIodi(int PreguntaIodiID)
        {
            var preguntaIodi = (from o in db.PreguntasIodis where o.PreguntasIodiID == PreguntaIodiID select o).Single();
            var preguntasIodiEdadDescripcion = "Todos";
            if (preguntaIodi.PreguntasIodiEdadID == 2)
            {
                preguntasIodiEdadDescripcion = "1°T";
            }
            if (preguntaIodi.PreguntasIodiEdadID == 3)
            {
                preguntasIodiEdadDescripcion = "2°T";
            }
            if (preguntaIodi.PreguntasIodiEdadID == 4)
            {
                preguntasIodiEdadDescripcion = "3°T";
            }
            if (preguntaIodi.PreguntasIodiEdadID == 5)
            {
                preguntasIodiEdadDescripcion = "4°T";
            }
            if (preguntaIodi.PreguntasIodiEdadID == 6)
            {
                preguntasIodiEdadDescripcion = "1 año";
            }
            if (preguntaIodi.PreguntasIodiEdadID == 7)
            {
                preguntasIodiEdadDescripcion = "2 años";
            }
            if (preguntaIodi.PreguntasIodiEdadID == 8)
            {
                preguntasIodiEdadDescripcion = "3 años";
            }

            var preguntasIodiclasificacion = "M";
            if (preguntaIodi.PreguntasIodiclasificacionID == 2)
            {
                preguntasIodiclasificacion = "C";
            }
            if (preguntaIodi.PreguntasIodiclasificacionID == 3)
            {
                preguntasIodiclasificacion = "SE";
            }
            if (preguntaIodi.PreguntasIodiclasificacionID == 4)
            {
                preguntasIodiclasificacion = "CVMC";
            }
            var preguntaIodiMostrar = new ListadoPreguntasIodi
            {
                PreguntasIodiID = preguntaIodi.PreguntasIodiID,
                PreguntasIodiDescripcion = preguntaIodi.PreguntasIodiDescripcion,
                PreguntasIodiEdadID = preguntaIodi.PreguntasIodiEdadID,
                PreguntasIodiEdadDescripcion = preguntasIodiEdadDescripcion.ToString(),
                PreguntasIodiclasificacionID = preguntaIodi.PreguntasIodiclasificacionID,
                PreguntasIodiclasificacion = preguntasIodiclasificacion.ToString(),
            };
            return Json(preguntaIodiMostrar, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarPreguntaIodi(int id)
        {
            PreguntasIodi preguntaIodi = db.PreguntasIodis.Find(id);
            preguntaIodi.Eliminado = true;
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
