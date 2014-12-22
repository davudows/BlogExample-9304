using BlogExample.Data.Orm;
using BlogExample.UI.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogExample.UI.Web.Controllers
{
    public class SiteBlogController : LayoutController
    {
        public ViewResult BlogContent(string pageSlug , string menuSlug )
        { 
          Blog blg =  Service.Blog.GetByPageSlug(pageSlug);
         IPagedList<Blog> blglist = Service.Blog.GetByCategory(menuSlug,1);
         BlogDetailModel model = new BlogDetailModel();
         model.Blog = blg;
         model.OtherBlogs = blglist;
          return View(model);
           
        }

        
    }
}