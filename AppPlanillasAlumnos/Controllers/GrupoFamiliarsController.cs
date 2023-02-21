using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AppPlanillasAlumnos.Data;
using AppPlanillasAlumnos.Models;

namespace AppPlanillasAlumnos.Controllers
{
    [Authorize]
    public class GrupoFamiliarsController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();
        private PacientesController PacientesController = new PacientesController();

        // GET: GrupoFamiliars
        public ActionResult Index()
        {
            ViewBag.PersonaID = new SelectList(db.Personas.OrderBy(p => p.PersonaApellidoNombre).ToList(), "PersonaID", "PersonaApellidoNombre");
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
            var grupoFamiliars = db.GrupoFamiliars.Include(g => g.Persona);
            return View(grupoFamiliars.ToList());

            
        }
        //GUARDAR
        public JsonResult GuardarGrupoFamiliar
        
            (string GrupoFamiliarApellidoNombre,
             int GrupoFamiliarDNI,
            Sexo GrupoFamiliarSexo,
            DateTime GrupoFamiliarNacimiento,
            string GrupoFamiliarSalud,
            int GrupoFamiliarIngresos,
            string GrupoFamiliarVinculo,
            string GrupoFamiliarEscolaridad,
            string GrupoFamiliarOcupacion,
            int PersonaID,
            int GrupoFamiliarID)
        {
            bool guardado = false;

            //CREAR / EDITAR
            if (GrupoFamiliarID == 0)
            {
                var existeGrupofamiliar = (from o in db.GrupoFamiliars where o.Eliminado == false && o.GrupoFamiliarDNI == GrupoFamiliarDNI && o.PersonaID == PersonaID select o).Count();
                if (existeGrupofamiliar == 0)
                {
                    var grupoFamiliar = new GrupoFamiliar
                    {
                        GrupoFamiliarApellidoNombre = GrupoFamiliarApellidoNombre.ToUpper(),
                        GrupoFamiliarDNI = GrupoFamiliarDNI,
                        GrupoFamiliarSexo = GrupoFamiliarSexo,
                        GrupoFamiliarNacimiento = GrupoFamiliarNacimiento,
                        GrupoFamiliarVinculo = GrupoFamiliarVinculo.ToUpper(),
                        GrupoFamiliarEscolaridad = GrupoFamiliarEscolaridad.ToUpper(),
                        GrupoFamiliarOcupacion = GrupoFamiliarOcupacion.ToUpper(),
                        GrupoFamiliarSalud = GrupoFamiliarSalud.ToUpper(),
                        GrupoFamiliarIngresos = GrupoFamiliarIngresos,
                        PersonaID = PersonaID
                    };
                    db.GrupoFamiliars.Add(grupoFamiliar);
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
                var DniExistente = (from o in db.GrupoFamiliars where o.Eliminado == false && o.GrupoFamiliarID != GrupoFamiliarID && o.GrupoFamiliarDNI == GrupoFamiliarDNI && o.PersonaID == PersonaID select o).Count();
                if (DniExistente > 0)
                {
                    guardado = false;
                }
                else
                {
                    GrupoFamiliar grupoFamiliar = db.GrupoFamiliars.Find(GrupoFamiliarID);
                    grupoFamiliar.GrupoFamiliarApellidoNombre = GrupoFamiliarApellidoNombre.ToUpper();
                    grupoFamiliar.GrupoFamiliarDNI = GrupoFamiliarDNI;
                    grupoFamiliar.GrupoFamiliarSexo = GrupoFamiliarSexo;
                    grupoFamiliar.GrupoFamiliarNacimiento = GrupoFamiliarNacimiento;
                    grupoFamiliar.GrupoFamiliarSalud = GrupoFamiliarSalud.ToUpper();
                    grupoFamiliar.GrupoFamiliarIngresos = GrupoFamiliarIngresos;
                    grupoFamiliar.GrupoFamiliarVinculo = GrupoFamiliarVinculo.ToUpper();
                    grupoFamiliar.GrupoFamiliarEscolaridad = GrupoFamiliarEscolaridad.ToUpper();
                    grupoFamiliar.GrupoFamiliarOcupacion = GrupoFamiliarOcupacion.ToUpper();
                    db.SaveChanges();
                    guardado = true;
                }

            }                 

            JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
           
        }
     
        //MOSTRAR LA TABLA 
        public JsonResult BuscarListadoGrupoFamiliar(int PersonaID)
        {
            List<ListadoGrupoFamiliar> grupofamiliaresmostrar = new List<ListadoGrupoFamiliar>();

            if (PersonaID > 0)
            { 
                var gruposfamiliares = (from o in db.GrupoFamiliars where o.PersonaID == PersonaID && o.Eliminado == false select o).ToList();

                foreach (var grupofamiliar in gruposfamiliares)
                {
                    var personamostrar = new ListadoPersonas
                    {
                        PersonaID = grupofamiliar.PersonaID,
                        PersonaApellidoNombre = grupofamiliar.Persona.PersonaApellidoNombre
                    };

                    var grupoFamiliarSexoString = "FEMENINO";
                    if (grupofamiliar.GrupoFamiliarSexo == Sexo.Masculino)
                    {
                        grupoFamiliarSexoString = "MACULINO";
                    }
                    if (grupofamiliar.GrupoFamiliarSexo == Sexo.Nobinario)
                    {
                        grupoFamiliarSexoString = "NO BINARIO";
                    }

                    var grupofamiliarmostrar = new ListadoGrupoFamiliar
                    {
                        GrupoFamiliarID = grupofamiliar.GrupoFamiliarID,
                        GrupoFamiliarApellidoNombre = grupofamiliar.GrupoFamiliarApellidoNombre.ToUpper(),
                        GrupoFamiliarDNI = grupofamiliar.GrupoFamiliarDNI,
                        GrupoFamiliarNacimientoString = grupofamiliar.GrupoFamiliarNacimiento.ToString("yyyy-MM-dd"),
                        GrupoFamiliarNacimiento = grupofamiliar.GrupoFamiliarNacimiento,
                        GrupoFamiliarSexo = grupofamiliar.GrupoFamiliarSexo,
                        GrupoFamiliarSexoString = grupoFamiliarSexoString,
                        GrupoFamiliarVinculo = grupofamiliar.GrupoFamiliarVinculo.ToUpper(),
                        GrupoFamiliarEscolaridad = grupofamiliar.GrupoFamiliarEscolaridad.ToUpper(),
                        GrupoFamiliarOcupacion = grupofamiliar.GrupoFamiliarOcupacion.ToUpper(),
                        GrupoFamiliarSalud = grupofamiliar.GrupoFamiliarSalud.ToUpper(),
                        GrupoFamiliarIngresos = grupofamiliar.GrupoFamiliarIngresos,
                        Personas = personamostrar
                    };
                    grupofamiliaresmostrar.Add(grupofamiliarmostrar);
                }
            }

            JsonResult resultado = Json(grupofamiliaresmostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }


        //MOSTRAR LOS DATOS PARA EDITAR 
        public JsonResult DatosIntegranteDeFamilia(int GrupoFamiliarID)
            {
                var grupofamiliar = db.GrupoFamiliars.Where(p => p.GrupoFamiliarID == GrupoFamiliarID).Single();
                var personamostrar = new ListadoPersonas
                {
                    PersonaID = grupofamiliar.PersonaID,
                    PersonaApellidoNombre = grupofamiliar.Persona.PersonaApellidoNombre

                };
                var grupofamiliarmostrar = new ListadoGrupoFamiliar{
                    GrupoFamiliarID = grupofamiliar.GrupoFamiliarID,
                    GrupoFamiliarApellidoNombre = grupofamiliar.GrupoFamiliarApellidoNombre.ToUpper(),
                    GrupoFamiliarDNI = grupofamiliar.GrupoFamiliarDNI,
                    GrupoFamiliarEscolaridad = grupofamiliar.GrupoFamiliarEscolaridad.ToUpper(),
                    GrupoFamiliarIngresos = grupofamiliar.GrupoFamiliarIngresos,
                    GrupoFamiliarNacimientoString = grupofamiliar.GrupoFamiliarNacimiento.ToString("yyyy-MM-dd"),
                    GrupoFamiliarOcupacion = grupofamiliar.GrupoFamiliarOcupacion.ToUpper(),
                    GrupoFamiliarSalud = grupofamiliar.GrupoFamiliarSalud.ToUpper(),
                    GrupoFamiliarSexo = grupofamiliar.GrupoFamiliarSexo,
                    GrupoFamiliarVinculo = grupofamiliar.GrupoFamiliarVinculo.ToUpper(),
                    Personas = personamostrar
                };

                return Json(grupofamiliarmostrar);
            }

        //ELIMINAR
        public JsonResult EliminarGrupoFamiliar(int id)
        {
            GrupoFamiliar grupoFamiliar = db.GrupoFamiliars.Find(id);
            grupoFamiliar.Eliminado = true;
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
