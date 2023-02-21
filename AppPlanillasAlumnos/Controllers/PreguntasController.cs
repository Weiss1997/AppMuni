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
    public class PreguntasController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: Preguntass
        public ActionResult Index()
        {
            ViewBag.PercentilEdadID = new SelectList(db.EdadPercentilMeses.OrderBy(p => p.EdadFormularioDescripcion).ToList(), "PercentilEdadID ", "EdadFormularioDescripcion");

            return View(db.Preguntas.ToList());
        }

        //APERTURA DE SECCIÓN GUARDAR PREGUNTAS//
        public JsonResult GuardarPregunta(int PreguntasID, string PreguntasNombre, 
            int TipoFormularioID, int PercentilEdadID)
        {
            bool guardado = false;
            
            if (PreguntasID == 0)
            {
                var existepregunta = (from o in db.Preguntas where o.PreguntasNombre == PreguntasNombre && o.TipoFormularioID == TipoFormularioID && o.PercentilEdadID == PercentilEdadID && o.Eliminado == false select o).Count();
                if (existepregunta == 0)
                {
                    var preguntas = new Preguntas
                    {
                        PreguntasID = PreguntasID,
                        PreguntasNombre = PreguntasNombre.ToUpper(),
                        TipoFormularioID = TipoFormularioID,
                        PercentilEdadID = PercentilEdadID
                    };
                    db.Preguntas.Add(preguntas);
                    db.SaveChanges();

                    guardado = true;

                }
                else
                {
                    guardado = false;
                }
            }
            else
            {
                Preguntas preguntas = db.Preguntas.Find(PreguntasID);

                preguntas.PreguntasID = PreguntasID;
                preguntas.PreguntasNombre = PreguntasNombre.ToUpper();
                preguntas.TipoFormularioID = TipoFormularioID;
                preguntas.PercentilEdadID = PercentilEdadID;
                db.SaveChanges();

                guardado = true;

            }

            JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }
        //CIERRE DE SECCIÓN GUARDAR//

        //APERTURA DE SECCIÓN BUSCAR/MOSTRAR PREGUNTAS//
        public JsonResult BuscarListadoPreguntas()
        {
            List<ListadoPreguntas> preguntasMostrar = new List<ListadoPreguntas>();

            var Preguntas = (from o in db.Preguntas where o.Eliminado == false select o).ToList();

            foreach (var pregunta in Preguntas)
            {
                var EdadMostrar = new ListadoEdadPercentil
                {
                    PercentilEdadID = pregunta.PercentilEdadID,
                    EdadFormularioDescripcion = pregunta.EdadPercentilMeses.EdadFormularioDescripcion,
                };
                var preguntaMostrar = new ListadoPreguntas
                {
                    PreguntasID = pregunta.PreguntasID,
                    PreguntasNombre = pregunta.PreguntasNombre,
                    TipoFormularioID = pregunta.TipoFormularioID,
                    EdadPercentil = EdadMostrar,
                };
                preguntasMostrar.Add(preguntaMostrar);
            }

            JsonResult resultado = Json(preguntasMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }
        //CIERRE DE SECCIÓN BUSCAR/MOSTRAR PREGUNTAS//

        //APERTURA DE SECCIÓN EDITAR PREGUNTAS//
        public JsonResult BuscarInfoPregunta (int PreguntasID)
         {
            var pregunta = db.Preguntas.Where(p => p.PreguntasID == PreguntasID).Single();
            var preguntaMostrar = new ListadoPreguntas
            {
                PreguntasID = pregunta.PreguntasID,
                PreguntasNombre = pregunta.PreguntasNombre,
                TipoFormularioID = pregunta.TipoFormularioID,
                EdadFormularioDescripcion = pregunta.EdadPercentilMeses.EdadFormularioDescripcion
            };
            return Json(preguntaMostrar, JsonRequestBehavior.AllowGet);
         }
        //CIERRE DE SECCIÓN EDITAR PREGUNTAS//

        //APERTURA DE SECCIÓN ELIMINAR PREGUNTAS//
        public JsonResult EliminarPregunta(int id)
        {
            Preguntas pregunta = db.Preguntas.Find(id);
            pregunta.Eliminado = true;
            db.SaveChanges();

            return Json(true);
        }
        //CIERRE DE SECCIÓN EDITAR PREGUNTAS//

        public JsonResult ValidacionEdadExiste(int PercentilEdadID)
        {
            var edadExiste = (from o in db.EdadPercentilMeses where o.PercentilEdadID == PercentilEdadID && o.Eliminado == false select o).Count();
            var validacion = true;
            if (edadExiste == 0)
            {
                validacion = false;
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
