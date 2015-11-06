using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoRestaurante.Startup))]
namespace ProyectoRestaurante
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
