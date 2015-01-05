using BlogExample.Data.Orm;
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

    [MenuAuthory(Types.EnumSiteMenu.Menu)]
    public class MenuController : AdminLayoutController
    {
        #region Insert

        public ViewResult Insert()
        {
            LoadLangDrop();
            SelectByLangId(1);

            return View();
        }

        [HttpPost]
        public JsonResult Insert(MenuModel model)
        {
            SiteMenu menu = new SiteMenu()
        {
            LangId = model.LangId,
            Name = model.Name,
            TopMenuId = model.TopMenuId == null ? 0 : (int)model.TopMenuId,

        };

            DataRequestResult result = Services.SiteMenu.Insert(menu);

            return Json(result.ToJson(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Edit

        public ViewResult Edit(int id)
        {
            LoadLangDrop();
            SelectByLangId(1);
            SiteMenu menu = Services.SiteMenu.Find(id);
            MenuModel model = new MenuModel()
            {
                LangId = menu.LangId,
                Name = menu.Name,
                TopMenuId = menu.TopMenuId,
            };
            return View(model);

        }
        [HttpPut]
        public JsonResult Edit(int id, MenuModel model)
        {
            SiteMenu entity = new SiteMenu();
            entity.Id = id;
            entity.Name = model.Name;
            entity.LangId = model.LangId;
            entity.TopMenuId = model.TopMenuId ?? 0;
            DataRequestResult result = Services.SiteMenu.Update(entity);
            return Json(result.ToJson(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region List

        
        [OutputCache(Duration=1)]
        public ViewResult List()
        {
            List<SiteMenu> siteMenus = Services.SiteMenu.GetAll();
            return View(siteMenus);
        }

        #endregion

        #region Delete

        [HttpPost]
        public JsonResult Delete(int id)
        {
            DataRequestResult result = Services.SiteMenu.Delete(id);
            return Json(result.ToJson(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Dropdowns
        public JsonResult SelectByLangId(int id)
        {
            List<SiteMenu> menuList = Services.SiteMenu.GetTopMenu(id);
            List<SelectListItem> menuSelect = menuList.Where(a => a.LangId == id).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();
            ViewData["menuList"] = menuSelect;
            return Json(menuSelect, JsonRequestBehavior.AllowGet);
        }

        public void LoadLangDrop()
        {
            List<Language> langList = Services.Language.GetAll();


            List<SelectListItem> langSelect = langList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),

            }).ToList();
            ViewData["langList"] = langSelect;
        }
        #endregion
    }
}