using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Routing;

namespace orate.Filters
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuario"];
            if (usuario != null)
            {
                base.OnActionExecuted(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary(new { controller = "Account", action = "Index" }));
            }


        }
    }
}