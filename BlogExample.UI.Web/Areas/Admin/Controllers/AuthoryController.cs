using BlogExample.Data.Dto.Admin;
using BlogExample.Data.Orm;
using BlogExample.Types;
using BlogExample.UI.Web.Areas.Admin.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogExample.UI.Web.Areas.Admin.Controllers
{
    [MenuAuthory(EnumSiteMenu.Authory)]
    public class AuthoryController : AdminLayoutController
    {

        #region List
        public ViewResult List()
        {
            List<AdminUser> userList = Services.AdminUser.GetAll();
            return View(userList);
        }
        #endregion

        #region SetAuhory

        public ViewResult SetAuthory(int id)
        {
            ViewBag.AdminId = id;
            List<AdminAuthoryDto> model = Services.AdminUser.GetAuthory(id);
            return View(model);
        }


        public void ChangeRole(int menuId , int adminId)
        {
            Services.AdminUser.ChangeAuthory(menuId , adminId);
        }
        #endregion

   
    }
}