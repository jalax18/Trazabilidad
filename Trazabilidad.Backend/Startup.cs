using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trazabilidad.Backend.Startup))]
namespace Trazabilidad.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
