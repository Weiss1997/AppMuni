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
    public class DatosAlumnosController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: DatosAlumnos
        public ActionResult Index()
        {
            return View(db.DatosAlumnos.ToList());
        }

        // GET: DatosAlumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosAlumnos datosAlumnos = db.DatosAlumnos.Find(id);
            if (datosAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(datosAlumnos);
        }

        // GET: DatosAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatosAlumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DatosAlumnosID,DatosAlumnosNombre,DatosAlumnosApellido")] DatosAlumnos datosAlumnos)
        {
            if (ModelState.IsValid)
            {
                db.DatosAlumnos.Add(datosAlumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datosAlumnos);
        }

        // GET: DatosAlumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosAlumnos datosAlumnos = db.DatosAlumnos.Find(id);
            if (datosAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(datosAlumnos);
        }

        // POST: DatosAlumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DatosAlumnosID,DatosAlumnosNombre,DatosAlumnosApellido")] DatosAlumnos datosAlumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosAlumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datosAlumnos);
        }

        // GET: DatosAlumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosAlumnos datosAlumnos = db.DatosAlumnos.Find(id);
            if (datosAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(datosAlumnos);
        }

        // POST: DatosAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosAlumnos datosAlumnos = db.DatosAlumnos.Find(id);
            db.DatosAlumnos.Remove(datosAlumnos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
