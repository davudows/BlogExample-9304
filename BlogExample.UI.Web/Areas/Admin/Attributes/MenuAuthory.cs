using BlogExample.Services.DataServices;
using BlogExample.Types;
using BlogExample.UI.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogExample.Extensions;
namespace BlogExample.UI.Web.Areas.Admin.Attributes
{
    public class MenuAuthory : ActionFilterAttribute
    {
        private int _menuId;
        public MenuAuthory(EnumSiteMenu menu)
        {
            this._menuId = menu.ToInt32();
        }

        public MenuAuthory(int id)
        {
            this._menuId = id;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          
            using (ServicePoint services = new ServicePoint())
            {
                bool anyAuthory = services.AdminUser.IsAuthory(_menuId, CurrentUser.Id);
                if (!anyAuthory)
                {
                    RouteValueDictionary routing = new RouteValueDictionary { { "action", "AuthoryError" }, { "controller", "AdminError" } };
                    filterContext.Result = new RedirectToRouteResult(routing);
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}