using BlogExample.Data.Orm;
using BlogExample.Services.DataServices;
using BlogExample.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogExample.UI.Web.Controllers
{
    public class LayoutController : Controller
    {
        protected ServicePoint Service;
        public LayoutController()
        {
            Service = new ServicePoint();
        }

        public PartialViewResult Menus()
        {
            List<SiteMenu> siteMenus = Service.SiteMenu.GetAll();
            List<MenuModel> model =
                siteMenus.Where(x => x.TopMenuId == 0).Select(y => new MenuModel
                {
                    Name = y.Name,
                    PageSlug = y.PageSlug,

                    SubMenus = siteMenus.Where(z => z.TopMenuId == y.Id).Select(z => new MenuModel
                    {
                        Name = z.Name,
                        PageSlug = y.PageSlug + "/" + z.Name,
                    }).ToList(),

                }).ToList();

            return PartialView("Partial/_siteMenu",model);
        }

        protected override void Dispose(bool disposing)
        {
            Service.Dispose();
            base.Dispose(disposing);
        }

    }
}