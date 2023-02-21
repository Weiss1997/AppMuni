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

    public class FormularioCPPPsController : Controller
    {
        private readonly AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: FormularioCPPPs1
        public ActionResult Index()
        {
            ViewBag.PersonaID = new SelectList(db.Personas.OrderBy(p => p.PersonaApellidoNombre).ToList(), "PersonaID", "PersonaApellidoNombre"); /*TIENE QUE ESTAR EL PERSONA
*/
            ViewBag.ProfesionalID = new SelectList(db.Profesionals.OrderBy(p => p.Persona.PersonaApellidoNombre).ToList(), "ProfesionalID", "PersonaApellidoNombre");
            var formularioCPPPs = db.FormularioCPPPs.Include(f => f.Profesional);
            return View(formularioCPPPs.ToList());

        }




        public JsonResult BuscarPreguntasFormularioCPPP(int FormularioCpppID, int TipoFormularioID, int PersonaID)
        {
            List<ListadoPreguntasFormularioCppp> preguntasMostrar = new List<ListadoPreguntasFormularioCppp>();

            //DE ACUERDO A LA PERSONA CORRESPONDIENTE AL FORMULARIO CPPP, BUSCAMOS EL REGISTRO EN LA TABLA DEL PRIMER FORMULARIO
            var formulario = (from o in db.Formularios where o.PersonaID == PersonaID && o.TipoFormularioID == TipoFormularioID && o.Eliminado == false select o).SingleOrDefault();

            //VALIDAMOS QUE EXISTA EL PRIMER FORMLARIO PARA ESA PERSONA
            if (formulario != null)
            {
                if (FormularioCpppID == 0)//CREAR FORMULARIO
                {
                    foreach (var detalleFormulario in formulario.DetalleFormularios)
                    {
                        var preguntaMostrar = new ListadoPreguntasFormularioCppp
                        {
                            PreguntasID = detalleFormulario.PreguntasID,
                            OpcionCumplimiento = OpcionCumplimiento.NOCUMPLE,
                            Cumple = false,
                            PreguntasNombre = detalleFormulario.Preguntas.PreguntasNombre,
                            OpcionRespuesta = detalleFormulario.OpcionRespuesta
                        };
                        preguntasMostrar.Add(preguntaMostrar);
                    }
                }
                else//ESTA EDITANDO EL FORMULARIO
                {
                    //BUSCAMOS LOS DETALLES DE LAS PREGUNTAS
                    var preguntas = (from o in db.DetalleCppps where o.FormularioCpppID == FormularioCpppID select o).ToList();

                    foreach (var pregunta in preguntas.OrderBy(p => p.PreguntasID))
                    {
                        //BUSCAMOS EN LA TABLA DE DETALLE FORMULARIO LA RESPUESTA DE ESA PREGUNTA
                        OpcionRespuesta opcionRespuesta = OpcionRespuesta.No;

                        var respuestaPreguntaFormulario = (from o in formulario.DetalleFormularios where o.PreguntasID == pregunta.PreguntasID select o).SingleOrDefault();
                        if (respuestaPreguntaFormulario != null)
                        {
                            opcionRespuesta = respuestaPreguntaFormulario.OpcionRespuesta;
                        }

                        var preguntaMostrar = new ListadoPreguntasFormularioCppp
                        {
                            PreguntasID = pregunta.PreguntasID,
                            OpcionCumplimiento = pregunta.OpcionCumplimiento,
                            Cumple = pregunta.Cumple,
                            PreguntasNombre = pregunta.Pregunta.PreguntasNombre,
                            OpcionRespuesta = opcionRespuesta
                        };
                        preguntasMostrar.Add(preguntaMostrar);
                    }
                }            
            }
            return Json(preguntasMostrar, JsonRequestBehavior.AllowGet);
        }

        //APERTURA DE SECCION GUARDAR
        public JsonResult GuardarCambios(int FormularioCpppID,
            int TipoFormularioID, int PersonaID,
            int[] PreguntasID, int[] Respuestas,
            int[] SeConsidera, bool Pasa, int ProfesionalID,
            string Observacion, string[] ListadoPreguntasFormularioCppp)

        {
            bool guardado = false;

            if (!String.IsNullOrEmpty(Observacion))
            {
                Observacion = Observacion.ToUpper();
            }


            if (FormularioCpppID == 0)
            {

                var existepersonaparaformulario = (from o in db.FormularioCPPPs where o.PersonaID == PersonaID && o.TipoFormularioID == TipoFormularioID && o.Eliminado == false select o).Count();
                if (existepersonaparaformulario == 0)
                {

                    using (var transaccion = db.Database.BeginTransaction())
                        try
                        {
                            var formularioCPPP = new FormularioCPPP
                            {
                                TipoFormularioID = TipoFormularioID,
                                ProfesionalID = ProfesionalID,
                                PersonaID = PersonaID,
                                Pasa = Pasa,
                                Observacion = Observacion,
                            };
                            db.FormularioCPPPs.Add(formularioCPPP);
                            db.SaveChanges();

                            //LUEGO SE GUARDAN LOS DETALLES DE PREGUNTAS CON SU CORRESPONDIENTE RESPUESTA
                            for (int i = 0; i < PreguntasID.Length; i++)
                            {
                                var preguntaID = PreguntasID[i];
                                var respuesta = Respuestas[i];
                                var seConsidera = SeConsidera[i];

                                bool cumple = true;
                                if (seConsidera == 0)
                                {
                                    cumple = false;
                                }

                                OpcionCumplimiento Opcion = OpcionCumplimiento.CUMPLE;
                                if (respuesta == 1)
                                {
                                    Opcion = OpcionCumplimiento.NOCUMPLE;
                                }

                                var DetalleCPPP = new DetalleCppp
                                {
                                    FormularioCpppID = formularioCPPP.FormularioCpppID,
                                    Cumple = cumple,
                                    PreguntasID = preguntaID,
                                    OpcionCumplimiento = Opcion
                                };
                                db.DetalleCppps.Add(DetalleCPPP);
                                db.SaveChanges();
                            }
                            guardado = true;

                            transaccion.Commit();

                        }
                        catch (Exception ex)
                        {
                            transaccion.Rollback();
                        }
                }
            }
            else
            {
                FormularioCPPP formularioCPPPs = db.FormularioCPPPs.Find(FormularioCpppID);

                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        formularioCPPPs.FormularioCpppID = FormularioCpppID;
                        formularioCPPPs.TipoFormularioID = TipoFormularioID;
                        formularioCPPPs.ProfesionalID = ProfesionalID;
                        formularioCPPPs.PersonaID = PersonaID;
                        formularioCPPPs.Pasa = Pasa;
                        formularioCPPPs.Observacion = Observacion;
                        db.SaveChanges();

                        //LUEGO SE GUARDAN LOS DETALLES DE PREGUNTAS CON SU CORRESPONDIENTE RESPUESTA
                        for (int i = 0; i < PreguntasID.Length; i++)
                        {
                            var preguntaID = PreguntasID[i];
                            var respuesta = Respuestas[i];

                            var seConsidera = SeConsidera[i];

                            bool cumple = true;
                            if (seConsidera == 0)
                            {
                                cumple = false;
                            }

                            OpcionCumplimiento Opcion = OpcionCumplimiento.CUMPLE;
                            if (respuesta == 1)
                            {
                                Opcion = OpcionCumplimiento.NOCUMPLE;
                            }

                            var DetalleCPPPeditar = (from o in db.DetalleCppps where o.PreguntasID == preguntaID && o.FormularioCpppID == formularioCPPPs.FormularioCpppID select o).Single();
                            DetalleCPPPeditar.OpcionCumplimiento = Opcion;
                            DetalleCPPPeditar.Cumple = cumple;
                            db.SaveChanges();

                        }
                        guardado = true;
                        transaccion.Commit();
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                    }
                }
            }


            return Json(guardado, JsonRequestBehavior.AllowGet);
        }

        //CIERRE DE SECCION GUARDAR


        //APERTURA SECCION BUSCAR/MOSTRAR FORMULARIO
        public JsonResult BuscarListadoFormularioCPPP()
        {
            List<ListadoFormularioCppp> FormulariocpppMostrar = new List<ListadoFormularioCppp>();

            var formularioCPPPs = (from o in db.FormularioCPPPs where o.Eliminado == false select o).ToList();

            foreach (var formulariocppp in formularioCPPPs)
            {
                var profesionalesMostrar = new ListadoProfesionales
                {
                    ProfesionalID = formulariocppp.ProfesionalID,
                    PersonaApellidoNombre = formulariocppp.Profesional.Persona.PersonaApellidoNombre,
                };

                var persona = (from o in db.Personas select o).Where(f => f.PersonaID == formulariocppp.PersonaID).Single();

                var personasMostrar = new ListadoPersonas
                {
                    PersonaID = formulariocppp.PersonaID,
                    PersonaApellidoNombre = persona.PersonaApellidoNombre,
                };

                var pasabool = "NO PASA";
                if (formulariocppp.Pasa == true)
                {
                    pasabool = "PASA";
                }

                var listado = new ListadoFormularioCppp
                {
                    FormularioCpppID = formulariocppp.FormularioCpppID,
                    TipoFormularioID = formulariocppp.TipoFormularioID,
                    Profesionales = profesionalesMostrar,
                    Persona = personasMostrar,
                    Observacion = formulariocppp.Observacion,
                    Pasa = formulariocppp.Pasa,
                    pasabool = pasabool,
                };
                FormulariocpppMostrar.Add(listado);
            }

            JsonResult resultado = Json(FormulariocpppMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        //CIERRE DE SECCION BUSCAR/MOSTRAR FORMULARIO

        //APERTURA DE SECCION EDITAR FORMULARIO
        public JsonResult BuscarInfoCppp(int FormularioCpppID)
        {
            //var formulariocppp = (from o in db.FormularioCPPPs where o.FormularioCpppID == FormularioCpppID select o).Single();
            var formulariocppp = db.FormularioCPPPs.Where(p => p.FormularioCpppID == FormularioCpppID).Single();
            var personaNombre = (from o in db.Personas where o.PersonaID == formulariocppp.PersonaID select o.PersonaApellidoNombre).Single();

            List<ListadoPreguntasFormularioCppp> listadoPreguntasFormularioCppp = new List<ListadoPreguntasFormularioCppp>();

            foreach (var detalle in formulariocppp.DetallesCppp)
            {
                var preguntaMostrar = new ListadoPreguntasFormularioCppp
                {
                    DetalleCpppID = detalle.DetalleCpppID,
                    PreguntasID = detalle.PreguntasID,
                    PreguntasNombre = detalle.Pregunta.PreguntasNombre,
                    Cumple = detalle.Cumple,
                    OpcionCumplimiento = detalle.OpcionCumplimiento,
                };
                listadoPreguntasFormularioCppp.Add(preguntaMostrar);
            }

            var formularioMostrar = new ListadoFormularioCppp
            {
                FormularioCpppID = formulariocppp.FormularioCpppID,
                TipoFormularioID = formulariocppp.TipoFormularioID,
                ProfesionalID = formulariocppp.ProfesionalID,
                PersonaApellidoNombreProfesional = formulariocppp.Profesional.Persona.PersonaApellidoNombre,
                PersonaID = formulariocppp.PersonaID,
                PersonaApellidoNombrePersona = personaNombre,
                Observacion = formulariocppp.Observacion,
                Pasa = formulariocppp.Pasa,
                ListadoPreguntasFormularioCppp = listadoPreguntasFormularioCppp,
            };
            return Json(formularioMostrar, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidacionPersonaExiste(int PersonaID, int TipoFormularioID)
        {
            var personaID = (from o in db.FormularioCPPPs where o.PersonaID == PersonaID && o.TipoFormularioID == TipoFormularioID && o.Eliminado == false select o).Count();
            var Validacion = true;
            if (personaID > 0)
            {
                Validacion = false;
            }
            return Json(Validacion);
        }
        public JsonResult EliminarFormCppp(int id)
        {
            FormularioCPPP formulariocppp = db.FormularioCPPPs.Find(id);
            formulariocppp.Eliminado = true;
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
