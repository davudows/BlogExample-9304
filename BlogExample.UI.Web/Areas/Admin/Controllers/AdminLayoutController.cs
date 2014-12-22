using BlogExample.Data.Orm;
using BlogExample.Services.DataServices;
using BlogExample.Types;
using BlogExample.UI.Web.Areas.Admin.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogExample.UI.Web.Areas.Admin.Controllers
{
   [LoginRequired]
    public class AdminLayoutController : Controller
    {

        protected ServicePoint Services;
       
        public AdminLayoutController()
        {
            Services = new ServicePoint();
            
        }

        public AdminLayoutController(EnumSiteMenu menu)
        {

        }

        public PartialViewResult SideMenus()
        {
            List<AdminMenu> model = Services.AdminUser.GetMenusByAdmin(1);
            return PartialView("~/Areas/Admin/Views/Shared/Partial/_sideMenu.cshtml",model);
        }

        protected override void Dispose(bool disposing)
        {
          
            Services.Dispose();
            base.Dispose(disposing);
        }

    }
}