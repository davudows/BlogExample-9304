using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogExample.UI.Web.Areas.Admin.Attributes
{
    public class LoginRequired : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
       {
          
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                RouteValueDictionary routing = new RouteValueDictionary{{"action","index"},{"controller","Login"}};
                filterContext.Result = new RedirectToRouteResult(routing);
            }
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}