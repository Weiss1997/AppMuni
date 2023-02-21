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
    public class TratamientoesController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BuscarListadoTratamientos()
        {
            List<ListadoTratamientos> tratamientosMostrar = new List<ListadoTratamientos>();

            var tratamientos = db.Tratamientos.Include(t => t.Paciente).Where(t=>t.Eliminado == false).OrderBy(t=>t.Paciente.Persona.PersonaApellidoNombre).ToList();

            foreach (var tratamiento in tratamientos)
            {
                var profesional = (from o in db.Profesionals where o.ProfesionalID == tratamiento.ProfesionalID select o).Single();

                var tratamientoMostrar = new ListadoTratamientos
                {
                    TratamientoID = tratamiento.TratamientoID,                 
                    TratamientoAnterior = tratamiento.TratamientoAnterior,
                    TratamientoActuales = tratamiento.TratamientoActuales,
                    PacienteNombre = tratamiento.Paciente.Persona.PersonaApellidoNombre.ToUpper(),
                    ProfesionalNombre = profesional.Persona.PersonaApellidoNombre.ToUpper(),
                };
                tratamientosMostrar.Add(tratamientoMostrar);
            }

            JsonResult resultado = Json(tratamientosMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }


        public JsonResult BuscarInfoTratamiento (int TratamientoID)
        {
            var tratamiento = db.Tratamientos.Where(t => t.TratamientoID == TratamientoID).Single();
            var profesional = (from o in db.Profesionals where o.ProfesionalID == tratamiento.ProfesionalID select o).Single();

            var tratamientoMostrar = new ListadoTratamientos
            {
                TratamientoID = tratamiento.TratamientoID,
                TratamientoAnterior = tratamiento.TratamientoAnterior.ToUpper(),
                TratamientoActuales = tratamiento.TratamientoActuales.ToUpper(),
                PacienteNombre = tratamiento.Paciente.Persona.PersonaApellidoNombre,
                PacienteID = tratamiento.PacienteID,
                ProfesionalID = tratamiento.ProfesionalID,
                ProfesionalNombre = profesional.Persona.PersonaApellidoNombre
            };

            JsonResult resultado = Json(tratamientoMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }


        public JsonResult GuardarTratamiento(string TratamientoAnterior, string TratamientoActuales, int ProfesionalID, int PacienteID, int TratamientoID)
        {
            bool guardado = false;

            if (TratamientoID == 0)
            {
                    var tratamiento = new Tratamiento
                    {
                        TratamientoAnterior = TratamientoAnterior.ToUpper(),
                        TratamientoActuales = TratamientoActuales.ToUpper(),
                        ProfesionalID = ProfesionalID,
                        PacienteID = PacienteID
                    };
                    db.Tratamientos.Add(tratamiento);
                    db.SaveChanges();
                    guardado = true;
            }
            else
            {
                var PacienteExiste = (from o in db.Tratamientos where o.PacienteID == PacienteID && o.TratamientoID == TratamientoID && o.Eliminado == false && o.ProfesionalID == ProfesionalID select o).Count();
                if (PacienteExiste > 0)
                {
                    Tratamiento tratamiento = db.Tratamientos.Find(TratamientoID);
                    tratamiento.TratamientoAnterior = TratamientoAnterior.ToUpper();
                    tratamiento.TratamientoActuales = TratamientoActuales.ToUpper();
                    //Comentado para un futuro//
                    //tratamiento.PacienteID = PacienteID;
                    //tratamiento.ProfesionalID = ProfesionalID;
                    db.SaveChanges();
                    guardado = true;
                }
            }
            JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        //Comentado para un futuro//
        //public JsonResult GuardarTratamiento(string TratamientoAnterior, string TratamientoActuales, int ProfesionalID, int PacienteID, int TratamientoID)
        //{
        //    bool guardado = false;

        //    if (TratamientoID == 0)
        //    {
        //        var PacienteExiste = (from o in db.Tratamientos where o.PacienteID == PacienteID && o.Eliminado == false && o.ProfesionalID == ProfesionalID select o).Count();
        //        if (PacienteExiste == 0)
        //        {
        //            var tratamiento = new Tratamiento
        //            {
        //                TratamientoAnterior = TratamientoAnterior.ToUpper(),
        //                TratamientoActuales = TratamientoActuales.ToUpper(),
        //                ProfesionalID = ProfesionalID,
        //                PacienteID = PacienteID
        //            };
        //            db.Tratamientos.Add(tratamiento);
        //            db.SaveChanges();
        //            guardado = true;
        //        }

        //    }
        //    else
        //    {
        //        var PacienteExiste = (from o in db.Tratamientos where o.PacienteID == PacienteID && o.TratamientoID == TratamientoID && o.Eliminado == false && o.ProfesionalID == ProfesionalID select o).Count();
        //        if (PacienteExiste > 0)
        //        {
        //            Tratamiento tratamiento = db.Tratamientos.Find(TratamientoID);
        //            tratamiento.TratamientoAnterior = TratamientoAnterior.ToUpper();
        //            tratamiento.TratamientoActuales = TratamientoActuales.ToUpper();
        //            //Comentado para un futuro//
        //            //tratamiento.PacienteID = PacienteID;
        //            //tratamiento.ProfesionalID = ProfesionalID;
        //            db.SaveChanges();
        //            guardado = true;
        //        }
        //    }
        //    JsonResult resultado = Json(guardado, JsonRequestBehavior.AllowGet);
        //    resultado.MaxJsonLength = Int32.MaxValue;
        //    return resultado;
        //}

        public JsonResult EliminarTratamiento(int id)
        {
            Tratamiento tratamiento = db.Tratamientos.Find(id);
            tratamiento.Eliminado = true;
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
