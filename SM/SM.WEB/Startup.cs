using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SM.WEB.Startup))]
namespace SM.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
