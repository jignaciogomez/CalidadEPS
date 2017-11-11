using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplicacionCalidad.Startup))]
namespace AplicacionCalidad
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
