using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSMVC.Startup))]
namespace DSMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
