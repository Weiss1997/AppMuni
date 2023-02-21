using System.Web;
using System.Web.Optimization;

namespace AppPlanillasAlumnos
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/dashtreme-master/assets/js/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/assets").Include(
                       "~/Content/dashtreme-master/assets/js/pace.min.js",
                       "~/Content/dashtreme-master/assets/plugins/simplebar/js/simplebar.js",
                       "~/Content/dashtreme-master/assets/js/app-script.js",
                       "~/Content/dashtreme-master/assets/js/jquery.min.js",
                       "~/Content/dashtreme-master/assets/js/popper.min.js",
                       "~/Content/dashtreme-master/assets/js/sidebar-menu.js"));



                       bundles.Add(new StyleBundle("~/Content/assets").Include(
                      "~/Content/dashtreme-master/assets/plugins/simplebar/css/simplebar.css",
                      "~/Content/dashtreme-master/assets/css/bootstrap.min.css",
                      "~/Content/dashtreme-master/assets/css/animate.css",
                      "~/Content/dashtreme-master/assets/css/icons.css",
                      "~/Content/dashtreme-master/assets/css/sidebar-menu.css",
                      "~/Content/dashtreme-master/assets/css/app-style.css",
                      "~/Content/Estilo3ro2021.css",
                      "~/Content/dashtreme-master/assets/css/pace.min.css"));

                      //             bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      //"~/Content/site.css"));
        }
    }
}
