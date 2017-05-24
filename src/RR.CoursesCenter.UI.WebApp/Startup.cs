using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RR.CoursesCenter.UI.WebApp.Startup))]
namespace RR.CoursesCenter.UI.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
