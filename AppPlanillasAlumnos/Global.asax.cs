using AppPlanillasAlumnos.Data;
using AppPlanillasAlumnos.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AppPlanillasAlumnos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<Data.AppPlanillasAlumnosContext,
                Migrations.Configuration>());

            ApplicationDbContext db = new ApplicationDbContext();

            // LLAMAMOS AL METODO QUE CREA EL USUARIO PRINCIPAL DEL SISTEMA.
            CrearUsuarioPrincipal(db);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);     
        }


        private void CrearUsuarioPrincipal(ApplicationDbContext db)
        {
            // EN ESTA LINEA PEDIMOS QUE NOS PERMITA MANIPULAR LOS DATOS DE LOS USUARIOS.
            var userManage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // DAMOS DE ALTA A UN USUARIO NUEVO.
            var cuentaPrincipal = userManage.FindByEmail("administrador@gmail.com");
            if (cuentaPrincipal == null)
            {
                cuentaPrincipal = new ApplicationUser
                {
                    UserName = "administrador@gmail.com",
                    Email = "administrador@gmail.com"
                };
                userManage.Create(cuentaPrincipal, "123456");
            }
        }
    }
}
