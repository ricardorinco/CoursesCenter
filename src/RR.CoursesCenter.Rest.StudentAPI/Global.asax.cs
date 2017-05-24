using RR.CoursesCenter.Application.AutoMapper;
using System.Web.Http;

namespace RR.CoursesCenter.Rest.StudentAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}
