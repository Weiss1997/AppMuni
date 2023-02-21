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
using AppPlanillasAlumnos.Models.SeguimientoInfantil;

namespace AppPlanillasAlumnos.Controllers
{
    [Authorize]
    public class InfantesEvaluadosController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: InfantesEvaluados
        public ActionResult Index()
        {
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
            return View(db.InfantesEvaluados.ToList());
        }

        //APERTURA DE SECCIÓN GUARDAR//
        public JsonResult GuardarInfanteEvaluado(DateTime InfantesEvaluadosFecha, string InfantesEvaluadosHistorialClinico,
            int PersonaID, string InfantesEvaluadosEdadCorregidaPrematuro, string InfantesEvaluadosRespuestaPrueba,
            string InfantesEvaluadosObservacion, string InfantesEvaluadosProximoControl, DateTime InfantesEvaluadosSegundoControl,
            string InfantesEvaluadosRespuestaPrueba2, string InfantesEvaluadosObservacion2, DateTime InfantesEvaluadosTercerControl,
            string InfantesEvaluadosRespuestaPrueba3, string InfantesEvaluadosObservacion3, DateTime InfantesEvaluadosCuartoControl,
            string InfantesEvaluadosRespuestaPrueba4, string InfantesEvaluadosObservacion4, int InfanteEvaluadoID)
        {
            bool guardado = false;
            if (InfanteEvaluadoID == 0)
            {
                var existepersona = (from o in db.InfantesEvaluados where o.PersonaID == PersonaID && o.Eliminado == false select o).Count();
                if (existepersona == 0)
                {
                    var infanteEvaluado = new InfantesEvaluados
                    {
                        InfantesEvaluadosFecha = InfantesEvaluadosFecha,
                        InfantesEvaluadosHistorialClinico = InfantesEvaluadosHistorialClinico,
                        PersonaID = PersonaID,
                        InfantesEvaluadosEdadCorregidaPrematuro = InfantesEvaluadosEdadCorregidaPrematuro.ToUpper(),
                        InfantesEvaluadosRespuestaPrueba = InfantesEvaluadosRespuestaPrueba.ToUpper(),
                        InfantesEvaluadosObservacion = InfantesEvaluadosObservacion,
                        InfantesEvaluadosProximoControl = InfantesEvaluadosProximoControl.ToUpper(),
                        InfantesEvaluadosSegundoControl = InfantesEvaluadosSegundoControl,
                        InfantesEvaluadosRespuestaPrueba2 = InfantesEvaluadosRespuestaPrueba2.ToUpper(),
                        InfantesEvaluadosObservacion2 = InfantesEvaluadosObservacion2,
                        InfantesEvaluadosTercerControl = InfantesEvaluadosTercerControl,
                        InfantesEvaluadosRespuestaPrueba3 = InfantesEvaluadosRespuestaPrueba3.ToUpper(),
                        InfantesEvaluadosObservacion3 = InfantesEvaluadosObservacion3,
                        InfantesEvaluadosCuartoControl = InfantesEvaluadosCuartoControl,
                        InfantesEvaluadosRespuestaPrueba4 = InfantesEvaluadosRespuestaPrueba4.ToUpper(),
                        InfantesEvaluadosObservacion4 = InfantesEvaluadosObservacion4,
                    };
                    db.InfantesEvaluados.Add(infanteEvaluado);
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
                InfantesEvaluados infanteEvaluado = db.InfantesEvaluados.Find(InfanteEvaluadoID);
                infanteEvaluado.InfantesEvaluadosFecha = InfantesEvaluadosFecha;
                infanteEvaluado.InfantesEvaluadosHistorialClinico = InfantesEvaluadosHistorialClinico;
                infanteEvaluado.PersonaID = PersonaID;
                infanteEvaluado.InfantesEvaluadosEdadCorregidaPrematuro = InfantesEvaluadosEdadCorregidaPrematuro;
                infanteEvaluado.InfantesEvaluadosRespuestaPrueba = InfantesEvaluadosRespuestaPrueba;
                infanteEvaluado.InfantesEvaluadosObservacion = InfantesEvaluadosObservacion;
                infanteEvaluado.InfantesEvaluadosProximoControl = InfantesEvaluadosProximoControl;
                infanteEvaluado.InfantesEvaluadosSegundoControl = InfantesEvaluadosSegundoControl;
                infanteEvaluado.InfantesEvaluadosRespuestaPrueba2 = InfantesEvaluadosRespuestaPrueba2;
                infanteEvaluado.InfantesEvaluadosObservacion2 = InfantesEvaluadosObservacion2;
                infanteEvaluado.InfantesEvaluadosTercerControl = InfantesEvaluadosTercerControl;
                infanteEvaluado.InfantesEvaluadosRespuestaPrueba3 = InfantesEvaluadosRespuestaPrueba3;
                infanteEvaluado.InfantesEvaluadosObservacion3 = InfantesEvaluadosObservacion3;
                infanteEvaluado.InfantesEvaluadosCuartoControl = InfantesEvaluadosCuartoControl;
                infanteEvaluado.InfantesEvaluadosRespuestaPrueba4 = InfantesEvaluadosRespuestaPrueba4;
                infanteEvaluado.InfantesEvaluadosObservacion4 = InfantesEvaluadosObservacion4;

                db.SaveChanges();

                guardado = true;
            }

            return Json(guardado, JsonRequestBehavior.AllowGet);
        }
        //CIERRE DE SECCIÓN GUARDAR//

        //APERTURA DE SECCIÓN BUSCAR/MOSTRAR INFANTE EVALUADO//
        public JsonResult BuscarListadoInfantesEvaluados()
        {
            List<ListadoInfantesEvaluados> infantesEvaluadosMostrar = new List<ListadoInfantesEvaluados>();

            var infantesEvaluados = (from o in db.InfantesEvaluados where o.Eliminado == false select o).ToList();

            foreach (var infanteEvaluado in infantesEvaluados)
            {
                var persona = db.Personas.Where(p => p.PersonaID == infanteEvaluado.PersonaID).Single();
                var infanteEvaluadoMostrar = new ListadoInfantesEvaluados
                {
                    InfantesEvaluadosID = infanteEvaluado.InfantesEvaluadosID,
                    InfantesEvaluadosFechaString = infanteEvaluado.InfantesEvaluadosFecha.ToString("dd/MM/yyyy"),
                    PersonaID = infanteEvaluado.PersonaID,
                    PersonaApellidoNombre = persona.PersonaApellidoNombre.ToUpper(),
                    PersonaSexoString = persona.PersonaSexo.ToString(),
                    PersonaFechaNacimientoString = persona.PersonaFechaNacimiento.ToString("dd/MM/yyyy"),
                    PersonaEdad = persona.Edad,
                };
                infantesEvaluadosMostrar.Add(infanteEvaluadoMostrar);
            }
            return Json(infantesEvaluadosMostrar, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BuscarInfoInfanteEvaluado(int InfanteEvaluadoID)
        {
            var infanteEvaluado = (from o in db.InfantesEvaluados where o.InfantesEvaluadosID == InfanteEvaluadoID select o).Single();
            var persona = (from o in db.Personas where o.PersonaID == infanteEvaluado.PersonaID select o).Single();

            var infanteEvaluadoMostrar = new ListadoInfantesEvaluados
            {
                InfantesEvaluadosID = infanteEvaluado.InfantesEvaluadosID,
                InfantesEvaluadosFechaString = infanteEvaluado.InfantesEvaluadosFecha.ToString("yyyy-MM-dd"),
                InfantesEvaluadosHistorialClinico = infanteEvaluado.InfantesEvaluadosHistorialClinico,
                PersonaID = infanteEvaluado.PersonaID,
                PersonaApellidoNombre = persona.PersonaApellidoNombre,
                PersonaEdad = persona.Edad,
                PersonaSexoString = persona.PersonaSexo.ToString(),
                PersonaFechaNacimientoString = persona.PersonaFechaNacimiento.ToString("yyyy-MM-dd"),
                InfantesEvaluadosEdadCorregidaPrematuro = infanteEvaluado.InfantesEvaluadosEdadCorregidaPrematuro,
                InfantesEvaluadosRespuestaPrueba = infanteEvaluado.InfantesEvaluadosRespuestaPrueba,
                InfantesEvaluadosObservacion = infanteEvaluado.InfantesEvaluadosObservacion,
                InfantesEvaluadosProximoControl = infanteEvaluado.InfantesEvaluadosProximoControl,
                InfantesEvaluadosSegundoControlString = infanteEvaluado.InfantesEvaluadosSegundoControl.ToString("yyyy-MM-dd"),
                InfantesEvaluadosRespuestaPrueba2 = infanteEvaluado.InfantesEvaluadosRespuestaPrueba2,
                InfantesEvaluadosObservacion2 = infanteEvaluado.InfantesEvaluadosObservacion2,
                InfantesEvaluadosTercerControlString = infanteEvaluado.InfantesEvaluadosTercerControl.ToString("yyyy-MM-dd"),
                InfantesEvaluadosRespuestaPrueba3 = infanteEvaluado.InfantesEvaluadosRespuestaPrueba3,
                InfantesEvaluadosObservacion3 = infanteEvaluado.InfantesEvaluadosObservacion3,
                InfantesEvaluadosCuartoControlString = infanteEvaluado.InfantesEvaluadosCuartoControl.ToString("yyyy-MM-dd"),
                InfantesEvaluadosRespuestaPrueba4 = infanteEvaluado.InfantesEvaluadosRespuestaPrueba4,
                InfantesEvaluadosObservacion4 = infanteEvaluado.InfantesEvaluadosObservacion4,
            };

            JsonResult resultado = Json(infanteEvaluadoMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }
        //CIERRE DE SECCIÓN BUSCAR/MOSTRAR INFANTE EVALUADO//

        //APERTURA DE SECCIÓN ELIMINAR//
        public JsonResult EliminarInfanteEvaluado(int id)
        {
            InfantesEvaluados infantesEvaluados = db.InfantesEvaluados.Find(id);
            infantesEvaluados.Eliminado = true;
            db.SaveChanges();

            return Json(true);
        }
        //CIERRE DE SECCIÓN ELIMINAR//

        public JsonResult ValidacionDePersonaExiste(int PersonaID)
        {
            var formularioPersona = (from o in db.Personas where o.PersonaID == PersonaID && o.Eliminado == false select o).Count();
            var validacion = true;
            if (formularioPersona == 0)
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
