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
using AppPlanillasAlumnos.Models.Discapacitados;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AppPlanillasAlumnos.Controllers
{
    [Authorize]
    public class PersonasController : Controller
    {
        private AppPlanillasAlumnosContext db = new AppPlanillasAlumnosContext();
        ApplicationDbContext dbusuarios = new ApplicationDbContext();


        // GET: Personas
        public ActionResult Index(int? ErrorEliminar)
        {

            ViewBag.ProvinciasID = new SelectList(db.Provincias.OrderBy(p => p.ProvinciasNombre).ToList(), "ProvinciasID", "ProvinciasNombre");

            var listadoPersonas = db.Personas.ToList();

            var usuarioName = User.Identity.GetUserName();
            //var persona_actual = (from p in db.PersonaSistemas where p.UsuarioID == usuarioName select p).SingleOrDefault();
            ViewBag.UsuarioNombre = usuarioName;

            return View(listadoPersonas);
        }

        public JsonResult BuscarListadoPersonas()
        {
            List<ListadoPersonas> personasMostrar = new List<ListadoPersonas>();

            List<ListadoEscuela> escuelasMostrar = new List<ListadoEscuela>();

            var personas = db.Personas.Include(p => p.Localidad).Where(l=>l.Eliminado == false).OrderBy(p=> p.PersonaApellidoNombre).ToList();

            foreach (var persona in personas)
            {
                var telefono = persona.PersonaTelefono;
                if (telefono == null)
                {
                    telefono = "";
                }
                var sexo = "";
                if (persona.PersonaSexo == Sexo.Femenino)
                {
                    sexo = "FEMENINO";
                }
                else if (persona.PersonaSexo == Sexo.Masculino)
                {
                    sexo = "MASCULINO";
                }
                else if (persona.PersonaSexo == Sexo.Nobinario)
                {
                    sexo = "NO BINARIO";
                }
                var personaMostrar = new ListadoPersonas
                {
                    PersonaID = persona.PersonaID,
                    PersonaApellidoNombre = persona.PersonaApellidoNombre,
                    PersonaFechaNacimientoString = persona.PersonaFechaNacimiento.ToString("dd/MM/yyyy"),
                    PersonaTelefono = telefono,
                    PersonaDireccion = persona.PersonaDireccion,
                    PersonaDNI = persona.PersonaDNI,
                    PersonaEdad = persona.Edad,
                    Escuelas = escuelasMostrar,
                    PersonaSexoString = sexo,
                    ObraSocialCual = persona.ObraSocialCual,
                    PersonaLocalidadNombre = persona.Localidad.LocalidadesNombre,
                };
                personasMostrar.Add(personaMostrar);
            }

            JsonResult resultado = Json(personasMostrar, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = Int32.MaxValue;
            return resultado;
        }

        public JsonResult BuscarPersonas(string texto)
        {
            List<ListadoPersonas> personasMostrar = new List<ListadoPersonas>();

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.ToUpper();
            }

            if (texto.Length > 2)
            {
                var personasEncontradas = db.Personas.Where(p => p.PersonaApellidoNombre.Contains(texto) && p.Eliminado == false)
                    .OrderBy(p=>p.PersonaApellidoNombre)
                    .Take(100)
                    .ToList();

                foreach (var persona in personasEncontradas)
                {
                    var personaMostrar = new ListadoPersonas
                    {
                        PersonaID = persona.PersonaID,
                        PersonaApellidoNombre = persona.PersonaApellidoNombre
                    };
                    personasMostrar.Add(personaMostrar);
                }
            }

            return Json(personasMostrar);
        }

        public JsonResult GuardarPersona(string PersonaApellidoNombre, string PersonaTelefono, int PersonaDNI, DateTime PersonaFechaNacimiento,
            string PersonaDireccion, int LocalidadesID, string PersonaCorreo, Sexo PersonaSexo, bool PersonaCovid,
            bool PersonaObraSocial, string ObraSocialCual, int PersonaID)

        {

            MetodoCrearEditarPersona(PersonaApellidoNombre, PersonaTelefono, PersonaDNI, PersonaFechaNacimiento,
            PersonaDireccion, LocalidadesID, PersonaCorreo, PersonaSexo, PersonaCovid,
            PersonaObraSocial, ObraSocialCual, ref PersonaID);

            return Json(PersonaID, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GuardarPersonaUsuario(string PersonaApellidoNombre, string PersonaTelefono, int PersonaDNI, DateTime PersonaFechaNacimiento,
        string PersonaDireccion, int LocalidadesID, string PersonaCorreo, Sexo PersonaSexo, bool PersonaCovid,
        bool PersonaObraSocial, string ObraSocialCual, int PersonaID, bool EsUsuario, string Email, string Constrasenia, TipoSistemas TipoSistemaID, int PersonaSistemaID)
        {

            MetodoCrearEditarPersona(PersonaApellidoNombre, PersonaTelefono, PersonaDNI, PersonaFechaNacimiento,
            PersonaDireccion, LocalidadesID, PersonaCorreo, PersonaSexo, PersonaCovid,
            PersonaObraSocial, ObraSocialCual, ref PersonaID);


            if (EsUsuario)
            {
                //VA EL CODIGO DE CREAR USUARIO Y EN LA TABLA DE PERSONA SISTEMA
                var PersonausuarioID = "";
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbusuarios)); //Manipular usuarios
                var nuevo_usuario = userManager.FindByEmail(Email);
                if (nuevo_usuario == null)
                {
                    nuevo_usuario = new ApplicationUser
                    {
                        UserName = Email,
                        Email = Email
                    };
                    userManager.Create(nuevo_usuario, Constrasenia);
                    PersonausuarioID = nuevo_usuario.Id;
                    var personaSistema = new PersonaSistema
                    {
                        PersonaID = PersonaID,
                        UsuarioID = PersonausuarioID,
                        TipoSistemas = TipoSistemaID
                    };
                    db.PersonaSistemas.Add(personaSistema);
                    db.SaveChanges();
                }
                else
                {
                    PersonaSistema personasistema = db.PersonaSistemas.Find(PersonaSistemaID);
                    personasistema.TipoSistemas = TipoSistemaID;
                }
            }

            return Json(PersonaID, JsonRequestBehavior.AllowGet);
        }

        public void MetodoCrearEditarPersona(string PersonaApellidoNombre, string PersonaTelefono, int PersonaDNI, DateTime PersonaFechaNacimiento,
            string PersonaDireccion, int LocalidadesID, string PersonaCorreo, Sexo PersonaSexo, bool PersonaCovid,
            bool PersonaObraSocial, string ObraSocialCual, ref int PersonaID)
        {

            if (ObraSocialCual != null)
            {
                ObraSocialCual = ObraSocialCual.ToUpper();
            }

            if (PersonaID == 0)
            {

                if (PersonaApellidoNombre != "")
                {
                   
                        var persona = new Persona
                        {
                            PersonaApellidoNombre = PersonaApellidoNombre.ToUpper(),
                            PersonaTelefono = PersonaTelefono,
                            PersonaDNI = PersonaDNI,
                            PersonaFechaNacimiento = PersonaFechaNacimiento,
                            PersonaDireccion = PersonaDireccion.ToUpper(),
                            LocalidadesID = LocalidadesID,
                            PersonaCorreo = PersonaCorreo.ToLower(),
                            PersonaSexo = PersonaSexo,
                            PersonaCovid = PersonaCovid,
                            PersonaObraSocial = PersonaObraSocial,
                            ObraSocialCual = ObraSocialCual.ToUpper()
                        };
                        db.Personas.Add(persona);
                        db.SaveChanges();
                        PersonaID = persona.PersonaID;
                    

                }

            }
            else
            {
                    Persona persona = db.Personas.Find(PersonaID);
                    persona.PersonaApellidoNombre = PersonaApellidoNombre.ToUpper();
                    persona.PersonaDNI = PersonaDNI;
                    persona.PersonaFechaNacimiento = PersonaFechaNacimiento;
                    persona.PersonaDireccion = PersonaDireccion.ToUpper();
                    persona.PersonaTelefono = PersonaTelefono;
                    persona.LocalidadesID = LocalidadesID;
                    persona.PersonaCorreo = PersonaCorreo.ToLower();
                    persona.PersonaSexo = PersonaSexo;
                    persona.PersonaCovid = PersonaCovid;
                    persona.PersonaObraSocial = PersonaObraSocial;
                    persona.ObraSocialCual = ObraSocialCual.ToUpper();
                    db.SaveChanges();
            }
            
        }
            
        public JsonResult ValidacionDNIExiste (int PersonaDNI, int PersonaID)
        {
            var Validaciondni = true;
            if (PersonaID == 0)
            {
                var DniExiste = (from o in db.Personas where o.PersonaDNI == PersonaDNI && o.Eliminado == false select o).Count();               
                if (DniExiste > 0)
                {
                    Validaciondni = false;
                }
            }
            else
            {
                var DniExiste = (from o in db.Personas where o.PersonaDNI == PersonaDNI && o.Eliminado == false select o).Count();
                if (DniExiste > 0)
                {
                    var Personasegundniexiste = (from o in db.Personas where o.PersonaDNI == PersonaDNI && o.PersonaID == PersonaID && o.Eliminado == false select o).Count();
                    if (Personasegundniexiste == 0)
                    {
                        Validaciondni = false;
                    }

                }
            }
           
            return Json(Validaciondni);
        }
        

    
    public JsonResult BuscarInfoPersona(int PersonaID)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbusuarios)); //Manipular usuarios
            var persona = db.Personas.Include(p => p.Localidad).Where(p => p.PersonaID == PersonaID && p.Eliminado == false).Single();
            var provincia = (from o in db.Localidades where o.LocalidadesID == persona.LocalidadesID select o.Provincia.ProvinciasNombre).Single();
            
            var emailUsuario = "";
            TipoSistemas tipoSistema = 0;
            var contraseniaSistema = "";
            var personaSistemaID = 0;
            var personasSistemaMostrar = (from o in db.PersonaSistemas where o.PersonaID == PersonaID select o).SingleOrDefault();
            
            if (personasSistemaMostrar != null)
            {
                var usuario = userManager.FindById(personasSistemaMostrar.UsuarioID);
                emailUsuario = usuario.Email;
                tipoSistema = personasSistemaMostrar.TipoSistemas;
                contraseniaSistema = "******";
                personaSistemaID = personasSistemaMostrar.PersonaSistemaID;
            }


            var personaMostrar = new ListadoPersonas
            {
                PersonaID = persona.PersonaID,
                PersonaApellidoNombre = persona.PersonaApellidoNombre,
                PersonaDireccion = persona.PersonaDireccion,
                PersonaTelefono = persona.PersonaTelefono,
                PersonaFechaNacimiento = persona.PersonaFechaNacimiento,
                PersonaFechaNacimientoString = persona.PersonaFechaNacimiento.ToString("yyyy-MM-dd"),
                PersonaEdad = persona.Edad,
                PersonaDNI = persona.PersonaDNI,
                PersonaLocalidadesID = persona.LocalidadesID,
                PersonaLocalidadNombre = persona.Localidad.LocalidadesNombre.ToUpper() + " / " + persona.Localidad.LocalidadesDepartamento.ToUpper() + " / " + provincia.ToUpper(),
                PersonaCorreo = persona.PersonaCorreo,
                PersonaSexo = persona.PersonaSexo,
                PersonaSexoString = persona.PersonaSexo.ToString(),
                PersonaCovid = persona.PersonaCovid,
                PersonaObraSocial = persona.PersonaObraSocial,
                ObraSocialCual = persona.ObraSocialCual,
                PersonaTipoSistema = tipoSistema,
                EmailUsuario = emailUsuario,
                ContraseniaSistema = contraseniaSistema,
                PersonaSistemaID = personaSistemaID
            };

            return Json(personaMostrar);
        }

        
        public JsonResult EliminarPersona(int id)
        {
            bool eliminar = true;

            var personaConDiscapacidad = (from o in db.PersonaConDiscapacidads where o.PersonaID == id select o).Count();
            var personaRelacionadaconinstituto = (from o in db.RelacioneInstitutoYPersonas where o.PersonaID == id select o).Count();
            var personaProfesional = (from o in db.Profesionals where o.PersonaID == id select o).Count();
            var personaCargo = (from o in db.PersonaldeInstitutos where o.PersonaID == id select o).Count();
            var personaDerivacion = (from o in db.Derivaciones where o.PersonaID == id select o).Count();
            var personaPaciente = (from o in db.Pacientes where o.PersonaID == id select o).Count();
            var personaFormulario = (from o in db.Formularios where o.PersonaID == id select o).Count();
            var personaInfante = (from o in db.InfantesEvaluados where o.PersonaID == id select o).Count();

            if (personaConDiscapacidad > 0 || personaRelacionadaconinstituto > 0 || personaProfesional > 0 || personaProfesional > 0
                && personaCargo > 0 || personaDerivacion > 0 || personaPaciente > 0 || personaFormulario > 0 || personaInfante > 0)
            {
                eliminar = false;
            }

            if (eliminar == true)
            {
                Persona persona = db.Personas.Find(id);
                persona.Eliminado = true;
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
