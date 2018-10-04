using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniaturesRUs.Startup))]
namespace MiniaturesRUs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
