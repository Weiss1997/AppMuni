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
    public class DesarrolloInfantilsController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: DesarrolloInfantils
        public ActionResult Index()
        {
            return View(db.DesarrolloInfantils.ToList());
        }

        public JsonResult GuardarDesarrolloInfantil(int PersonaID)
        {
            bool guardado = true;
            var existepersona = (from o in db.DesarrolloInfantils where o.PersonaID == PersonaID && o.Eliminado == false select o).Count();
            if (existepersona > 0)
            {
                guardado = false;

            }
            var desarrolloInfantilID = 0;
            if (guardado == true)
            {
                var desarrolloInfantil = new DesarrolloInfantil
                {
                    PersonaID = PersonaID,
                    DesarrolloInfantilEdadGestionalAlNacer = ""
                };
                db.DesarrolloInfantils.Add(desarrolloInfantil);
                db.SaveChanges();

                var preguntasIodi = (from o in db.PreguntasIodis where o.Eliminado == false select o).ToList();
                foreach (var preguntaIodi in preguntasIodi.OrderBy(p => p.PreguntasIodiEdadID))
                {
                    var detalleDesarrolloInfantil = new DetalleDesarrolloInfantil
                    {
                        DesarrolloInfantilID = desarrolloInfantil.DesarrolloInfantilID,
                        PreguntasIodiID = preguntaIodi.PreguntasIodiID
                    };
                    db.DetallesDesarrolloInfantil.Add(detalleDesarrolloInfantil);
                    db.SaveChanges();
                }
                desarrolloInfantilID = desarrolloInfantil.DesarrolloInfantilID;
            }

            return Json(desarrolloInfantilID, JsonRequestBehavior.AllowGet);
        }

        //APERTURA SECCION BUSCAR/MOSTRAR FORMULARIO
        public JsonResult BuscarListadoDesarrolloInfantil()
        {
            List<ListadoDesarrolloInfantil> desarrollosInfantilesMostrar = new List<ListadoDesarrolloInfantil>();

            var desarrolloIsnfantiles = (from o in db.DesarrolloInfantils select o).Where(d => d.Eliminado == false).OrderBy(d=>d.Persona.PersonaApellidoNombre).ToList();

            foreach (var desarrolloInfantil in desarrolloIsnfantiles)
            {
                var desarrolloInfantilMostrar = new ListadoDesarrolloInfantil
                {
                    DesarrolloInfantilID = desarrolloInfantil.DesarrolloInfantilID,
                    PersonaID = desarrolloInfantil.PersonaID,
                    PersonaApellidoNombre = desarrolloInfantil.Persona.PersonaApellidoNombre.ToUpper(),
                    PersonaFechaNacimientoString = desarrolloInfantil.Persona.PersonaFechaNacimiento.ToString("dd/MM/yyyy"),
                    DesarrolloInfantilEdadGestionalAlNacer = desarrolloInfantil.DesarrolloInfantilEdadGestionalAlNacer,
                };
                desarrollosInfantilesMostrar.Add(desarrolloInfantilMostrar);
            }

            JsonResult resultado = Json(desarrollosInfantilesMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }
        //CIERRE DE SECCION BUSCAR/MOSTRAR FORMULARIO

        //MÉTODO QUE BUSCA LA INFORMACIÓN DEL DESARROLLO INFANTIL CON SUS DETALLES
        public JsonResult BuscarInfoDesarrolloInfantil(int DesarrolloInfantilID)
        {
            var desarrolloInfantil = (from o in db.DesarrolloInfantils where o.DesarrolloInfantilID == DesarrolloInfantilID select o).Single();

            List<ListadoDetalleDesarrolloInfantil> listadoDetalleDesarrolloInfantil = new List<ListadoDetalleDesarrolloInfantil>();

            foreach (var detalle in desarrolloInfantil.DetalleDesarrolloInfantil)
            {
                var detalleDesarrolloInfantilMostrar = new ListadoDetalleDesarrolloInfantil
                {
                    DetalleDesarrolloInfantilID = detalle.DetalleDesarrolloInfantilID,
                    PreguntasIodiID = detalle.PreguntasIodiID,
                    PreguntasIodiDescripcion = detalle.PreguntasIodi.PreguntasIodiDescripcion,
                    CuadroColorUno = detalle.CuadroColorUno,
                    CuadroColorDos = detalle.CuadroColorDos,
                    CuadroColorTres = detalle.CuadroColorTres,
                    CuadroColorCuatro = detalle.CuadroColorCuatro,
                    CuadroColorCinco = detalle.CuadroColorCinco,
                    CuadroColorSeis = detalle.CuadroColorSeis,
                    CuadroColorSiete = detalle.CuadroColorSiete,
                    CuadroColorOcho = detalle.CuadroColorOcho,
                    CuadroColorNueve = detalle.CuadroColorNueve,
                    CuadroColorDiez = detalle.CuadroColorDiez,
                    CuadroColorOnce = detalle.CuadroColorOnce,
                    CuadroColorDoce = detalle.CuadroColorDoce,
                    CuadroColorTrece = detalle.CuadroColorTrece,
                    CuadroColorCatorce = detalle.CuadroColorCatorce,
                    CuadroColorQuince = detalle.CuadroColorQuince,
                    CuadroColorDieciseis = detalle.CuadroColorDieciseis,
                };
                listadoDetalleDesarrolloInfantil.Add(detalleDesarrolloInfantilMostrar);
            }

            var desarrolloInfantilMostrar = new ListadoDesarrolloInfantil
            {
                DesarrolloInfantilID = desarrolloInfantil.DesarrolloInfantilID,
                PersonaID = desarrolloInfantil.PersonaID,
                PersonaApellidoNombre = desarrolloInfantil.Persona.PersonaApellidoNombre,
                PersonaFechaNacimientoString = desarrolloInfantil.Persona.PersonaFechaNacimiento.ToString("dd/MM/yyyy"),
                DesarrolloInfantilEdadGestionalAlNacer = desarrolloInfantil.DesarrolloInfantilEdadGestionalAlNacer,
                DesarrolloInfantilObservacion = desarrolloInfantil.DesarrolloInfantilObservacion,
                ListadoDetalleDesarrolloInfantil = listadoDetalleDesarrolloInfantil,
            };
            return Json(desarrolloInfantilMostrar, JsonRequestBehavior.AllowGet);
        }

        //BUSCA LA INFORMACION DE UN DETALLE EN PARTICULAR DE UN DESARROLLO INFANTIL 
        public JsonResult BuscarInfoDetalle(int DetalleDesarrolloInfantilID)
        {
            var detalleDesarrolloInfantil = (from o in db.DetallesDesarrolloInfantil where o.DetalleDesarrolloInfantilID == DetalleDesarrolloInfantilID select o).Single();

            var detalleDesarrolloInfantilMostrar = new ListadoDetalleDesarrolloInfantil
            {
                DetalleDesarrolloInfantilID = detalleDesarrolloInfantil.DetalleDesarrolloInfantilID,
                PreguntasIodiID = detalleDesarrolloInfantil.PreguntasIodiID,
                PreguntasIodiDescripcion = detalleDesarrolloInfantil.PreguntasIodi.PreguntasIodiDescripcion,
                CuadroColorUno = detalleDesarrolloInfantil.CuadroColorUno,
                CuadroColorDos = detalleDesarrolloInfantil.CuadroColorDos,
                CuadroColorTres = detalleDesarrolloInfantil.CuadroColorTres,
                CuadroColorCuatro = detalleDesarrolloInfantil.CuadroColorCuatro,
                CuadroColorCinco = detalleDesarrolloInfantil.CuadroColorCinco,
                CuadroColorSeis = detalleDesarrolloInfantil.CuadroColorSeis,
                CuadroColorSiete = detalleDesarrolloInfantil.CuadroColorSiete,
                CuadroColorOcho = detalleDesarrolloInfantil.CuadroColorOcho,
                CuadroColorNueve = detalleDesarrolloInfantil.CuadroColorNueve,
                CuadroColorDiez = detalleDesarrolloInfantil.CuadroColorDiez,
                CuadroColorOnce = detalleDesarrolloInfantil.CuadroColorOnce,
                CuadroColorDoce = detalleDesarrolloInfantil.CuadroColorDoce,
                CuadroColorTrece = detalleDesarrolloInfantil.CuadroColorTrece,
                CuadroColorCatorce = detalleDesarrolloInfantil.CuadroColorCatorce,
                CuadroColorQuince = detalleDesarrolloInfantil.CuadroColorQuince,
                CuadroColorDieciseis = detalleDesarrolloInfantil.CuadroColorDieciseis,
            };

            return Json(detalleDesarrolloInfantilMostrar, JsonRequestBehavior.AllowGet);
        }


        //MÉTODO PARA GUARDAR LOS CAMBIOS DEL DETALLE
        public JsonResult GuardarDetalle(int DetalleDesarrolloInfantilID, int CuadroColorUno, int CuadroColorDos, int CuadroColorTres,
            int CuadroColorCuatro, int CuadroColorCinco, int CuadroColorSeis, int CuadroColorSiete, int CuadroColorOcho, int CuadroColorNueve,
            int CuadroColorDiez, int CuadroColorOnce, int CuadroColorDoce, int CuadroColorTrece, int CuadroColorCatorce, int CuadroColorQuince, 
            int CuadroColorDieciseis)
        {
            bool resultado = true;

            var detalleDesarrolloInfantil = (from o in db.DetallesDesarrolloInfantil where o.DetalleDesarrolloInfantilID == DetalleDesarrolloInfantilID select o).Single();
            detalleDesarrolloInfantil.CuadroColorUno = CuadroColorUno;
            detalleDesarrolloInfantil.CuadroColorDos = CuadroColorDos;
            detalleDesarrolloInfantil.CuadroColorTres = CuadroColorTres;
            detalleDesarrolloInfantil.CuadroColorCuatro = CuadroColorCuatro;
            detalleDesarrolloInfantil.CuadroColorCinco = CuadroColorCinco;
            detalleDesarrolloInfantil.CuadroColorSeis = CuadroColorSeis;
            detalleDesarrolloInfantil.CuadroColorSiete = CuadroColorSiete;
            detalleDesarrolloInfantil.CuadroColorOcho = CuadroColorOcho;
            detalleDesarrolloInfantil.CuadroColorNueve = CuadroColorNueve;
            detalleDesarrolloInfantil.CuadroColorDiez = CuadroColorDiez;
            detalleDesarrolloInfantil.CuadroColorOnce = CuadroColorOnce;
            detalleDesarrolloInfantil.CuadroColorDoce = CuadroColorDoce;
            detalleDesarrolloInfantil.CuadroColorTrece = CuadroColorTrece;
            detalleDesarrolloInfantil.CuadroColorCatorce = CuadroColorCatorce;
            detalleDesarrolloInfantil.CuadroColorQuince = CuadroColorQuince;
            detalleDesarrolloInfantil.CuadroColorDieciseis = CuadroColorDieciseis;

            db.SaveChanges();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GuardarDatosDePlanilla(int DesarrolloInfantilID, string DesarrolloInfantilEdadGestionalAlNacer, string DesarrolloInfantilObservacion)
        {
            bool resultado = true;

            var desarrolloInfantil = (from o in db.DesarrolloInfantils where o.DesarrolloInfantilID == DesarrolloInfantilID select o).Single();
            desarrolloInfantil.DesarrolloInfantilID = DesarrolloInfantilID;
            desarrolloInfantil.DesarrolloInfantilEdadGestionalAlNacer = DesarrolloInfantilEdadGestionalAlNacer;
            desarrolloInfantil.DesarrolloInfantilObservacion = DesarrolloInfantilObservacion;

            db.SaveChanges();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarPreguntasIodiDesarrolloInfantil(int PreguntasIodiEdadID)
        {
            List<ListadoPreguntasIodi> preguntasIodiMostrar = new List<ListadoPreguntasIodi>();

            var preguntasIodi = (from o in db.PreguntasIodis where o.PreguntasIodiEdadID == PreguntasIodiEdadID /*&& o.Eliminado == false*/ select o).ToList();
            foreach (var preguntaIodi in preguntasIodi.OrderBy(p => p.PreguntasIodiEdadID))
            {
                var preguntaIodiMostrar = new ListadoPreguntasIodi
                {
                    PreguntasIodiID = preguntaIodi.PreguntasIodiID,
                    PreguntasIodiDescripcion = preguntaIodi.PreguntasIodiDescripcion
                };
                preguntasIodiMostrar.Add(preguntaIodiMostrar);
            }

            return Json(preguntasIodiMostrar, JsonRequestBehavior.AllowGet);
        }
       
        // GET: DesarrolloInfantils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesarrolloInfantil desarrolloInfantil = db.DesarrolloInfantils.Find(id);
            if (desarrolloInfantil == null)
            {
                return HttpNotFound();
            }
            return View(desarrolloInfantil);
        }
     
        // GET: DesarrolloInfantils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesarrolloInfantil desarrolloInfantil = db.DesarrolloInfantils.Find(id);
            if (desarrolloInfantil == null)
            {
                return HttpNotFound();
            }
            return View(desarrolloInfantil);
        }
        public JsonResult EliminarDesarrolloInfantil(int id)
        {
            DesarrolloInfantil desarrolloInfantil = db.DesarrolloInfantils.Find(id);
            desarrolloInfantil.Eliminado = true;
            db.SaveChanges();

            return Json(true);
        }

        public JsonResult ValidacionDePersonaExistente(int PersonaID)
        {
            var desarrolloInfanilPersona = (from o in db.Personas where o.PersonaID == PersonaID && o.Eliminado == false select o).Count();
            var validacion = true;
            if (desarrolloInfanilPersona == 0)
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
