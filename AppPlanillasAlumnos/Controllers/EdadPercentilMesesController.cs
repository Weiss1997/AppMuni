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

namespace AppPlanillasAlumnos.Models
{
    [Authorize]
    public class EdadPercentilMesesController : Controller
    {
        private readonly AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        public EdadPercentilMeses PercentilEdadID { get; private set; }

        // GET: EdadPercentilMeses
        public ActionResult Index()
        {
            return View(db.EdadPercentilMeses.ToList());
        }


        public JsonResult GuardarEdadFormulario(int PercentilEdadID, string EdadFormularioDescripcion, int TipoPercentil)
        {
            bool guardado = false;
            var existeedad = (from o in db.EdadPercentilMeses where o.EdadFormularioDescripcion == EdadFormularioDescripcion && o.TipoPercentil == TipoPercentil && o.Eliminado == false select o).Count();

            if (existeedad == 0)
            {
                if (PercentilEdadID == 0)
                {
                    var EdadPercentilMeses = new EdadPercentilMeses
                    {
                        PercentilEdadID = PercentilEdadID,
                        EdadFormularioDescripcion = EdadFormularioDescripcion.ToUpper(),
                        TipoPercentil = TipoPercentil,
                    };
                    db.EdadPercentilMeses.Add(EdadPercentilMeses);
                    db.SaveChanges();
                    guardado = true;

                }
                else
                {
                    EdadPercentilMeses edadPercentilMeses = db.EdadPercentilMeses.Find(PercentilEdadID);
                    {
                        edadPercentilMeses.PercentilEdadID = PercentilEdadID;
                        edadPercentilMeses.EdadFormularioDescripcion = EdadFormularioDescripcion.ToUpper();
                        edadPercentilMeses.TipoPercentil = TipoPercentil;
                        db.SaveChanges();
                        guardado = true;
                    }
                }
            }
            else
            {
                guardado = false; 
            }
            
            JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }
        public JsonResult BuscarListadoEdadFormularios()
        {
            List<ListadoEdadPercentil> listadoEdadPercentils = new List<ListadoEdadPercentil>();

            var EdadPercentilMeses = (from o in db.EdadPercentilMeses select o).Where(e => e.Eliminado == false).ToList();


            foreach (var edadPercentilMeses in EdadPercentilMeses )
            {
                var percentiltipo = "PERCENTIL 90";
                if (edadPercentilMeses.TipoPercentil == 1)
                {
                    percentiltipo = "PERCENTIL 75";
                }

                var listado = new ListadoEdadPercentil
                {
                    PercentilEdadID = edadPercentilMeses.PercentilEdadID,
                    EdadFormularioDescripcion = edadPercentilMeses.EdadFormularioDescripcion,
                    TipoPercentil = edadPercentilMeses.TipoPercentil,
                    percentiltipo = percentiltipo
                };
                listadoEdadPercentils.Add(listado);
            }

            JsonResult resultado = Json(listadoEdadPercentils, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult BuscarEDAD(string texto)
        {
            List<ListadoEdadPercentil> EdadMostrar = new List<ListadoEdadPercentil>();

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.ToUpper();
            }

            if (texto.Length > 1)
            {
                var edadesencontradas = db.EdadPercentilMeses.Where(e => e.EdadFormularioDescripcion.Contains(texto))
                    .OrderBy(p => p.EdadFormularioDescripcion)
                    .Take(100)
                    .ToList();

                foreach (var edadPercentilMeses in edadesencontradas)
                {
                    var listadoEdadPercentil = new ListadoEdadPercentil
                    {
                        PercentilEdadID = edadPercentilMeses.PercentilEdadID,
                        EdadFormularioDescripcion = edadPercentilMeses.EdadFormularioDescripcion
                    };
                    EdadMostrar.Add(listadoEdadPercentil);
                }

                EdadMostrar = EdadMostrar.OrderBy(e => e.EdadFormularioDescripcion).ToList();
            }
            return Json(EdadMostrar);
        }


        // GET: EdadPercentilMeses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EdadPercentilMeses edadPercentilMeses = db.EdadPercentilMeses.Find(id);
            if (edadPercentilMeses == null)
            {
                return HttpNotFound();
            }
            return View(edadPercentilMeses);
        }

        // GET: EdadPercentilMeses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EdadPercentilMeses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PercentilEdadID,EdadFormularioDescripcion,TipoPercentil")] EdadPercentilMeses edadPercentilMeses)
        {
            if (ModelState.IsValid)
            {
                db.EdadPercentilMeses.Add(edadPercentilMeses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(edadPercentilMeses);
        }

        // GET: EdadPercentilMeses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EdadPercentilMeses edadPercentilMeses = db.EdadPercentilMeses.Find(id);
            if (edadPercentilMeses == null)
            {
                return HttpNotFound();
            }
            return View(edadPercentilMeses);
        }

        // POST: EdadPercentilMeses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PercentilEdadID,EdadFormularioDescripcion,TipoPercentil")] EdadPercentilMeses edadPercentilMeses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edadPercentilMeses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edadPercentilMeses);
        }

        //APERTURA DE SECCIÓN EDITAR //
        public JsonResult BuscarInfoEdad(int PercentilEdadID)
        {
            //var edadPercentilMeses = (from o in db.EdadPercentilMeses where o.PercentilEdadID == PercentilEdadID select o).Single();
            var edadPercentilMeses = db.EdadPercentilMeses.Where(p => p.PercentilEdadID == PercentilEdadID).Single();
            var listado = new ListadoEdadPercentil
            {
                PercentilEdadID = edadPercentilMeses.PercentilEdadID,
                EdadFormularioDescripcion = edadPercentilMeses.EdadFormularioDescripcion.ToUpper(),
                TipoPercentil = edadPercentilMeses.TipoPercentil,
            };
            return Json(listado, JsonRequestBehavior.AllowGet);
        }
        //CIERRE DE SECCIÓN EDITAR EDAD//



        //Eliminar
        public JsonResult EliminarEdadPercentil(int id)
        {
            EdadPercentilMeses PercentilEdadID = db.EdadPercentilMeses.Find(id);
            PercentilEdadID.Eliminado = true;
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

