using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibreriaV6.Startup))]
namespace LibreriaV6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
