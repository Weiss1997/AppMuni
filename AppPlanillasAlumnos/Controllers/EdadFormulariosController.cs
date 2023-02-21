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
    public class EdadFormulariosController : Controller
    {
        private readonly AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: EdadFormularios
        public ActionResult Index()
        {
            return View(db.EdadFormularios.ToList());
        }

        //APERTURA DE SECCIÓN GUARDAR EDAD
        public JsonResult GuardarEdadFormulario(string EdadFormularioDescripcion, int TipoFormularioID, int EdadFormulariosID)
        {
            bool guardado = false;

            if (EdadFormulariosID == 0)
            {
                var existeedad = (from o in db.EdadFormularios where o.EdadFormularioDescripcion == EdadFormularioDescripcion && o.TipoFormularioID == TipoFormularioID && o.Eliminado == false select o).Count();
                if (existeedad == 0)
                {
                    if (EdadFormularioDescripcion != "")
                    {
                        var edadFormularios = new EdadFormulario
                        {
                            EdadFormularioDescripcion = EdadFormularioDescripcion,
                            TipoFormularioID = TipoFormularioID
                        };
                        db.EdadFormularios.Add(edadFormularios);
                        db.SaveChanges();

                        guardado = true;
                    }
                }
                else
                {
                    guardado = false;
                }
            }
            else
            {
                EdadFormulario edadFormularios = db.EdadFormularios.Find(EdadFormulariosID);
                if (EdadFormularioDescripcion != "")
                {

                    edadFormularios.EdadFormularioDescripcion = EdadFormularioDescripcion;
                    edadFormularios.TipoFormularioID = TipoFormularioID;

                    db.SaveChanges();

                    guardado = true;
                }
            }
            return Json(guardado, JsonRequestBehavior.AllowGet);
        }
        //CIERRE DE SECCIÓN GUARDAR EDAD

        //APERTURA DE SECCIÓN BUSCAR/MOSTRAR EDAD
        public JsonResult BuscarListadoEdadFormularios()
        {
            List<ListadoEdadFormularios> edadFormulariosMostrar = new List<ListadoEdadFormularios>();

            var edadFormulario = db.EdadFormularios.Where(t => t.Eliminado == false).ToList();

            foreach (var edadFormularios in edadFormulario)
            {
                var edadFormularioMostrar = new ListadoEdadFormularios
                {
                    EdadFormularioID = edadFormularios.EdadFormularioID,
                    EdadFormularioDescripcion = edadFormularios.EdadFormularioDescripcion,
                    TipoFormularioID = edadFormularios.TipoFormularioID
                };
                edadFormulariosMostrar.Add(edadFormularioMostrar);
            }
            return Json(edadFormulariosMostrar, JsonRequestBehavior.AllowGet);
        }
        //CIERRE DE SECCIÓN BUSCAR/MOSTRAR EDAD

        //APERTURA DE SECCIÓN EDITAR EDAD
        public JsonResult BuscarInfoEdadFormularios(int EdadFormulariosID)
        {
            var edadFormulario = (from o in db.EdadFormularios where o.EdadFormularioID == EdadFormulariosID select o).Single();
            var edadFormularioMostrar = new ListadoEdadFormularios
            {
                EdadFormularioID = edadFormulario.EdadFormularioID,
                EdadFormularioDescripcion = edadFormulario.EdadFormularioDescripcion,
                TipoFormularioID = edadFormulario.TipoFormularioID
            };
            return Json(edadFormularioMostrar, JsonRequestBehavior.AllowGet);
        }
        //CIERRE DE SECCIÓN EDITAR EDAD

        //APERTURA DE SECCIÓN ELIMINAR EDAD
        public JsonResult EliminarEdadFormulario(int id)
        {
            EdadFormulario edadFormulario = db.EdadFormularios.Find(id);
            edadFormulario.Eliminado = true;
            db.SaveChanges();

            return Json(true);
        }
        //CIERRE DE SECCIÓN BUSCAR/MOSTRAR EDAD

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
