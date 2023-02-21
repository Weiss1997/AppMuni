using AppPlanillasAlumnos.Data;
using AppPlanillasAlumnos.Models.SeguimientoInfantil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AppPlanillasAlumnos.Controllers
{
    [Authorize]
    public class FormulariosController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();

        // GET: Formularios
        public ActionResult Index()
        {
            var formularios = db.Formularios.Include(f => f.Escuela).Include(f => f.Persona);
            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");
            ViewBag.NivelEducativoID = new SelectList(db.NivelEducativoes, "NivelEducativoID", "Niveles");
            return View(formularios.ToList());
        }

        //APERTURA DE SECCION GUARDAR
        public JsonResult GuardarFormulario(DateTime Fecha, string Peso, int TipoFormularioID, int PersonaID, int EscuelaID,
        string PersonaACargoNombreApellido, string PersonaACargoParentezco, string PersonaACargoEdad,
        string PersonaACargoDireccion, string PersonaACargoBarrio, string PersonaACargoLocalidad, string PersonaACargoTelefono,
        int NivelEducativoID, int[] PreguntasID, int[] Respuestas, int FormularioID)
        {
            bool guardado = false;
            if (FormularioID == 0)
            {
                var existepersona = (from o in db.Formularios where o.PersonaID == PersonaID && o.TipoFormularioID == TipoFormularioID && o.Eliminado == false select o).Count();
                if (existepersona == 0)
                {
                    using (var transaccion = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var formulario = new Formularios
                            {
                                Fecha = Fecha,
                                TipoFormularioID = TipoFormularioID,
                                Peso = Peso.ToUpper(),
                                PersonaACargoNombreApellido = PersonaACargoNombreApellido.ToUpper(),
                                PersonaACargoParentezco = PersonaACargoParentezco.ToUpper(),
                                PersonaACargoEdad = PersonaACargoEdad.ToUpper(),
                                PersonaACargoDireccion = PersonaACargoDireccion.ToUpper(),
                                PersonaACargoBarrio = PersonaACargoBarrio.ToUpper(),
                                PersonaACargoLocalidad = PersonaACargoLocalidad.ToUpper(),
                                PersonaACargoTelefono = PersonaACargoTelefono.ToUpper(),
                                NivelEducativoID = NivelEducativoID,
                                PersonaID = PersonaID,
                                EscuelaID = EscuelaID,
                            };
                            db.Formularios.Add(formulario);
                            db.SaveChanges();

                            //LUEGO SE GUARDAN LOS DETALLES DE PREGUNTAS CON SU CORRESPONDIENTE RESPUESTA
                            for (int i = 0; i < PreguntasID.Length; i++)
                            {
                                var preguntaID = PreguntasID[i];
                                var respuesta = Respuestas[i];

                                OpcionRespuesta opcionRespuesta = OpcionRespuesta.No;
                                if (respuesta == 1)
                                {
                                    opcionRespuesta = OpcionRespuesta.Si;
                                }
                                if (respuesta == 2)
                                {
                                    opcionRespuesta = OpcionRespuesta.Nose;
                                }
                                var detalleFormulario = new DetalleFormulario
                                {
                                    FormulariosID = formulario.FormulariosID,
                                    PreguntasID = preguntaID,
                                    OpcionRespuesta = opcionRespuesta
                                };
                                db.DetalleFormularios.Add(detalleFormulario);
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
                else
                {
                    guardado = false;
                }
            }
            else
            {
                
                    Formularios formulario = db.Formularios.Find(FormularioID);

                    using (var transaccion = db.Database.BeginTransaction())
                    {
                        try
                        {
                            formulario.Fecha = Fecha;
                            formulario.TipoFormularioID = TipoFormularioID;
                            formulario.Peso = Peso;
                            formulario.PersonaACargoNombreApellido = PersonaACargoNombreApellido;
                            formulario.PersonaACargoParentezco = PersonaACargoParentezco;
                            formulario.PersonaACargoEdad = PersonaACargoEdad;
                            formulario.PersonaACargoDireccion = PersonaACargoDireccion;
                            formulario.PersonaACargoBarrio = PersonaACargoBarrio;
                            formulario.PersonaACargoLocalidad = PersonaACargoLocalidad;
                            formulario.PersonaACargoTelefono = PersonaACargoTelefono;
                            formulario.NivelEducativoID = NivelEducativoID;
                            formulario.PersonaID = PersonaID;
                            formulario.EscuelaID = EscuelaID;
                            db.SaveChanges();

                            //LUEGO SE GUARDAN LOS DETALLES DE PREGUNTAS CON SU CORRESPONDIENTE RESPUESTA
                            for (int i = 0; i < PreguntasID.Length; i++)
                            {
                                var preguntaID = PreguntasID[i];
                                var respuesta = Respuestas[i];

                                OpcionRespuesta opcionRespuesta = OpcionRespuesta.No;
                                if (respuesta == 1)
                                {
                                    opcionRespuesta = OpcionRespuesta.Si;
                                }
                                if (respuesta == 2)
                                {
                                    opcionRespuesta = OpcionRespuesta.Nose;
                                }

                                var detalleFormularioEditar = (from o in db.DetalleFormularios where o.PreguntasID == preguntaID && o.FormulariosID == formulario.FormulariosID select o).Single();
                                detalleFormularioEditar.OpcionRespuesta = opcionRespuesta;
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
        public JsonResult BuscarListadoFormularios()
        {
            List<ListadoFormularios> formulariosMostrar = new List<ListadoFormularios>();

            var formularios = (from o in db.Formularios select o).Where(f => f.Eliminado == false).OrderBy(f=>f.Persona.PersonaApellidoNombre).ToList();

            foreach (var formulario in formularios)
            {
                var formularioMostrar = new ListadoFormularios
                {
                    FormulariosID = formulario.FormulariosID,
                    FechaString = formulario.Fecha.ToString("dd/MM/yyyy"),
                    PersonaID = formulario.PersonaID,
                    PersonaApellidoNombre = formulario.Persona.PersonaApellidoNombre.ToUpper(),
                    TipoFormularioID = formulario.TipoFormularioID,
                    PersonaACargoNombreApellido = formulario.PersonaACargoNombreApellido.ToUpper(),
                    EscuelaID = formulario.EscuelaID,
                    EscuelaNombre = formulario.Escuela.EscuelaNombre,
                };
                formulariosMostrar.Add(formularioMostrar);
            }

            JsonResult resultado = Json(formulariosMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }
        //CIERRE DE SECCION BUSCAR/MOSTRAR FORMULARIO

        //APERTURA DE SECCION EDITAR FORMULARIO
        public JsonResult BuscarInfoFormulario(int FormularioID)
        {
            var formulario = (from o in db.Formularios where o.FormulariosID == FormularioID select o).Single();

            List<ListadoPreguntasFormulario> listadoPreguntasFormulario = new List<ListadoPreguntasFormulario>();

            foreach (var detalle in formulario.DetalleFormularios)
            {
                var preguntaMostrar = new ListadoPreguntasFormulario
                {
                    DetalleFormularioID = detalle.DetalleFormularioID,
                    PreguntasID = detalle.PreguntasID,
                    PreguntasNombre = detalle.Preguntas.PreguntasNombre,
                    OpcionRespuesta = detalle.OpcionRespuesta,
                };
                listadoPreguntasFormulario.Add(preguntaMostrar);
            }

            var formularioMostrar = new ListadoFormularios
            {
                FormulariosID = formulario.FormulariosID,
                FechaString = formulario.Fecha.ToString("yyyy-MM-dd"),
                TipoFormularioID = formulario.TipoFormularioID,
                Peso = formulario.Peso,
                PersonaACargoNombreApellido = formulario.PersonaACargoNombreApellido,
                PersonaACargoParentezco = formulario.PersonaACargoParentezco,
                PersonaACargoEdad = formulario.PersonaACargoEdad,
                PersonaACargoDireccion = formulario.PersonaACargoDireccion,
                PersonaACargoBarrio = formulario.PersonaACargoBarrio,
                PersonaACargoLocalidad = formulario.PersonaACargoLocalidad,
                PersonaACargoTelefono = formulario.PersonaACargoTelefono,
                NivelEducativoID = formulario.NivelEducativoID,
                EscuelaID = formulario.EscuelaID,
                EscuelaNombre = formulario.Escuela.EscuelaNombre,
                PersonaID = formulario.PersonaID,
                PersonaApellidoNombre = formulario.Persona.PersonaApellidoNombre,
                PersonaDNI = formulario.Persona.PersonaDNI,
                PersonaEdad = formulario.Persona.Edad,
                PersonaFechaNacimientoString = formulario.Persona.PersonaFechaNacimiento.ToString("yyyy-MM-dd"),
                ListadoPreguntasFormulario = listadoPreguntasFormulario,
            };
            return Json(formularioMostrar, JsonRequestBehavior.AllowGet);
        }
        //CIERRE DE SESION EDITAR FORMULARIO

        //APERTURA DE ELIMINAR FORMULARIO
        public JsonResult EliminarFormulario(int id)
        {
            Formularios formulario = db.Formularios.Find(id);
            formulario.Eliminado = true;
            db.SaveChanges();

            return Json(true);
        }
        //CIERRE DE SESION ELIMINAR FORMULARIO

        //APERTURA DE BUSCAR PREGUNTA FORMULARIO
        public JsonResult BuscarPreguntasFormulario(int TipoFormularioID)
        {
            List<ListadoPreguntas> preguntasMostrar = new List<ListadoPreguntas>();

            var preguntas = (from o in db.Preguntas where o.TipoFormularioID == TipoFormularioID && o.Eliminado == false select o).ToList();
            foreach (var pregunta in preguntas.OrderBy(p => p.TipoFormularioID))
            {
                var preguntaMostrar = new ListadoPreguntas
                {
                    PreguntasID = pregunta.PreguntasID,
                    PreguntasNombre = pregunta.PreguntasNombre
                };
                preguntasMostrar.Add(preguntaMostrar);
            }

            return Json(preguntasMostrar, JsonRequestBehavior.AllowGet);
        }
        //CIERRE DE SESION BUSCAR PREGUNTA FORMULARIO

        //APERTURA DE SESION BUSCAR EDAD FORMULARIO
        public JsonResult BuscarEdadFormulario(int TipoFormularioID)
        {
            List<ListadoEdadFormularios> edadesMostrar = new List<ListadoEdadFormularios>();

            var edades = (from o in db.EdadFormularios where o.TipoFormularioID == TipoFormularioID && o.Eliminado == false select o).ToList();
            foreach (var edad in edades.OrderBy(p => p.TipoFormularioID))
            {
                var edadMostrar = new ListadoEdadFormularios
                {
                    EdadFormularioID = edad.EdadFormularioID,
                    EdadFormularioDescripcion = edad.EdadFormularioDescripcion
                };
                edadesMostrar.Add(edadMostrar);
            }

            return Json(edadesMostrar, JsonRequestBehavior.AllowGet);
        }
        //CIERRE DE SESION BUSCAR EDAD FORMULARIO

        public JsonResult ValidacionDePersonaExistente(int PersonaID, int EscuelaID)
        {
            var formularioPersona = (from o in db.Personas where o.PersonaID == PersonaID && o.Eliminado == false select o).Count();
            var validacion = true;
            if (formularioPersona == 0)
            {
                validacion = false;
            }
            var formularioEscuela = (from o in db.Escuelas where o.EscuelaID == EscuelaID && o.Eliminado == false select o).Count();
            if (formularioEscuela == 0)
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

