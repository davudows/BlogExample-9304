using BlogExample.Data.Orm;
using BlogExample.Services.DataServices;
using BlogExample.UI.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogExample.UI.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {


        private ServicePoint _servicePoint = new ServicePoint();
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (!ModelState.IsValid) return View();

            AdminUser user = _servicePoint.AdminUser.Login(model.UserName, model.Password);
            if (user == null)
            {
                ViewBag.Response = "Giriş bilgileriniz yanlış..!";
                return View();
            }
            string authoryCookie = String.Format("{0};{1};{2}", user.Id, user.UserName, user.Mail);
            FormsAuthentication.SetAuthCookie(authoryCookie, true);

            return RedirectToAction("Index", "AdminHome");


        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            _servicePoint.Dispose();
            base.Dispose(disposing);
        }
    }
}