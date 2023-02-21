using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppPlanillasAlumnos.Startup))]
namespace AppPlanillasAlumnos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
