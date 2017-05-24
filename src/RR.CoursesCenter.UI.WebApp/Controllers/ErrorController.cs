using System.Web.Mvc;

namespace RR.CoursesCenter.UI.WebApp.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(int? code)
        {
            return View("_Error");
        }

        public ActionResult AccessDenied()
        {
            return View("_AccessDenied");
        }

        public ActionResult NotFound()
        {
            return View("_NotFound");
        }
    }
}