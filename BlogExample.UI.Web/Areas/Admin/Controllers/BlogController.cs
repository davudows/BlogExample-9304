using BlogExample.Data.Orm;
using BlogExample.Services.DataServices;
using BlogExample.Services.UploadServices;
using BlogExample.Types;
using BlogExample.UI.Web.Areas.Admin.Attributes;
using BlogExample.UI.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogExample.UI.Web.Areas.Admin.Controllers
{
    [MenuAuthory(EnumSiteMenu.Blog)]
    public class BlogController : AdminLayoutController
    {

        public ActionResult List()
        {
            List<Blog> model = Services.Blog.GetAll();

            return View(model);
        }

        #region Insert

        public ViewResult Insert()
        {
            return View();
        }

        [HttpPost]
    
        public JsonResult Insert(HttpPostedFileBase resim, BlogModel model)
        {
            string path = "";
            if (resim != null)
            {

                FileUploadResult result = ImageUploadService.CreateService(resim).Upload("~/Content/uploaded", model.Title);
                if (!result.IsSuccess)
                {
                    return Json(result.ToJson(), JsonRequestBehavior.AllowGet);
                }
                path = result.FilePath;
            }


            Blog blog = new Blog()
            {
                Tag = model.Tags,
                Title = model.Title,
                Description = model.Description,
                BlogContent = model.HtmlContent,
                ImagePath = path,
                AdminId = CurrentUser.Id,
                MenuId =1002, // HACK Get menu ıd generic,
                PageSlug = UrlYap(model.Title),
                IsActive = true,
            };

            DataRequestResult dataResult = Services.Blog.Insert(blog);

            return Json(dataResult.ToJson(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Update

        public ViewResult Update(int id)
        {
            Blog model = Services.Blog.Find(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult Update(Blog blog)
        {
            JsonResponse response = Services.Blog.Update(blog).ToJson();

            return Json(response, JsonRequestBehavior.AllowGet);
        }



        #endregion

        private string UrlYap(string data)
        {
            data = data.Replace(",", "").Replace("\"", "").Replace("'", "").Replace(":", "").Replace(";", "").Replace(".", "").Replace("!", "").Replace("?", "").Replace(")", "").Replace("(", " ").Replace("&", " ").Replace(" ", " "); if (data.Length > 75)
            {
                data = data.Substring(0, 75);
                data = data.Substring(0, data.LastIndexOf(" "));
            }
            data = data.Replace(" ", "-").ToLower();
            return data.Replace("ş", "s").Replace("Ş", "s").Replace("ç", "c").Replace("Ç", "c").Replace("ö", "o").Replace("Ö", "o").Replace("ü", "u").Replace("Ü", "u").Replace("İ", "i").Replace("ı", "i").Replace("ğ", "g").Replace("Ğ", "g");
        }

    }
}