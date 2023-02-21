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
    public class LocalidadesController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: Localidades
        public ActionResult Index()
        {
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
            return View(db.Localidades.ToList());

        }
       


        public JsonResult BuscarListadoLocalidades()
        {
            List<ListadoLocalidades> localidadesMostrar = new List<ListadoLocalidades>();

            var localidades = db.Localidades.Include(P=> P.Provincia).Where(p=>p.Eliminado == false).OrderBy(l =>l.LocalidadesNombre).ToList();

            foreach (var localidad in localidades)
            {
                var provinciaMostrar = new ListadoProvincias
                {
                    ProvinciasID = localidad.ProvinciasID,
                    ProvinciasNombre = localidad.Provincia.ProvinciasNombre.ToUpper(),
                };

                var localidadMostrar = new ListadoLocalidades
                {
                    LocalidadesID = localidad.LocalidadesID,
                    LocalidadesNombre = localidad.LocalidadesNombre.ToUpper(),
                    LocalidadesDepartamento = localidad.LocalidadesDepartamento.ToUpper(),
                    Provincia = provinciaMostrar
                };
                localidadesMostrar.Add(localidadMostrar);
            }

            JsonResult resultado = Json(localidadesMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult BuscarLocalidades(string texto)
        {
            List<ListadoLocalidades> localidadesMostrar = new List<ListadoLocalidades>();

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.ToUpper();
            }

            if (texto.Length > 2)
            {
                var localidadesEncontradas = db.Localidades.Where(p => p.LocalidadesNombre.Contains(texto) && p.Eliminado == false)
                    .Include(p => p.Provincia)
                    .OrderBy(p => p.LocalidadesNombre)
                    .Take(100)
                    .ToList();

                foreach (var localidad in localidadesEncontradas)
                {
                    var localidadMostrar = new ListadoLocalidades
                    {
                        LocalidadesID = localidad.LocalidadesID,
                        LocalidadesNombre = localidad.LocalidadesNombre + " / " + localidad.LocalidadesDepartamento + " / " + localidad.Provincia.ProvinciasNombre
                    };
                    localidadesMostrar.Add(localidadMostrar);
                }
            }


            return Json(localidadesMostrar);
        }

        


        public JsonResult GuardarLocalidad(string LocalidadesNombre, string LocalidadesDepartamento, int ProvinciasID, int LocalidadesID)

        {
            int localidadID = 0;
            if (LocalidadesID == 0)
            {
                if (LocalidadesNombre != "")
                {

                    var localidad = new Localidades
                    {
                        LocalidadesNombre = LocalidadesNombre.ToUpper(),
                        LocalidadesDepartamento = LocalidadesDepartamento.ToUpper(),
                        ProvinciasID = ProvinciasID,
                    };
                    db.Localidades.Add(localidad);
                    db.SaveChanges();
                    localidadID = localidad.LocalidadesID;
                }
            }
            else
            {
                Localidades localidades = db.Localidades.Find(LocalidadesID);
                localidades.LocalidadesNombre = LocalidadesNombre.ToUpper();
                localidades.LocalidadesDepartamento = LocalidadesDepartamento.ToUpper();
                localidades.ProvinciasID = ProvinciasID;
                db.SaveChanges();
            }

            return Json(localidadID, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarNombreLocalidad(string LocalidadesNombre, int ProvinciasID, string LocalidadesDepartamento)
        {
            var LocalidadExiste = (from o in db.Localidades where o.LocalidadesNombre == LocalidadesNombre && 
                                   o.LocalidadesDepartamento == LocalidadesDepartamento && o.ProvinciasID == ProvinciasID &&
                                   o.Eliminado == false select o).Count();
            var Validacionlocalidad = true;
            if (LocalidadExiste > 0)
            {
                Validacionlocalidad = false;
            }
            return Json(Validacionlocalidad);
        }

    public JsonResult BuscarInfoLocalidad(int LocalidadesID)
        {
            var localidad = db.Localidades.Include(p => p.Provincia).Where(d => d.LocalidadesID == LocalidadesID).Single();

            var localidadMostrar = new ListadoLocalidades
            {
                LocalidadesID = localidad.LocalidadesID,
                LocalidadesNombre = localidad.LocalidadesNombre,
                LocalidadesDepartamento = localidad.LocalidadesDepartamento,
                ProvinciasID = localidad.ProvinciasID,
                LocalidadesNombreCompleto = localidad.LocalidadesNombre + " / " + localidad.LocalidadesDepartamento + " / " + localidad.Provincia.ProvinciasNombre
            };

            return Json(localidadMostrar);
        }


        public JsonResult EliminarLocalidad(int id)
        {
            bool eliminar = true;

            var localidadPersona = (from o in db.Personas where o.LocalidadesID == id select o).Count();

            if (localidadPersona > 0)
            {
                eliminar = false;
            }

            if (eliminar == true)
            {
                Localidades localidades = db.Localidades.Find(id);
                localidades.Eliminado = true;
                db.SaveChanges();
            }

            JsonResult resultado = Json(eliminar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
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
