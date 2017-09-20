using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Deals4All.Startup))]
namespace Deals4All
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
