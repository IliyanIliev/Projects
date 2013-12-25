using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieSystem.Web.Startup))]
namespace MovieSystem.Web
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
