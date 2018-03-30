using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GillyBeanCentral.Startup))]
namespace GillyBeanCentral
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
