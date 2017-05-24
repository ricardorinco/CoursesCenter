using System.Web.Mvc;

namespace RR.CoursesCenter.UI.WebApp.Filters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                // Manipular a EX
                // Injetar algumas LIB de tratamento de erro
                //  -> Gravar log do erro na Base de Dados
                //  -> Email para o administrador
                //  -> Retornar código de erro amigável

                // Sempre de forma ASYNC
                filterContext.ExceptionHandled = true;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}