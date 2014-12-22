using BlogExample.Data.Orm;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogExample.UI.Web.Controllers
{
    public class SiteMenuController : LayoutController
    {
        public ViewResult MenuContent(string menuSlug,int? page)
        {
            int currentPage = page ?? 1;
            IPagedList<Blog> blogList = Service.Blog.GetByCategory(menuSlug,currentPage);
            ViewBag.Title = menuSlug;
            ViewBag.MenuSlug = menuSlug;
            return View(blogList);
        }
   
    }
}