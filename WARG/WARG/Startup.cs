using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WARG.Startup))]
namespace WARG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
