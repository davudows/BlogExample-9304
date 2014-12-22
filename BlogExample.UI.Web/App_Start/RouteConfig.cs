using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogExample.UI.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         
            routes.MapRoute("Menu", "{menuSlug}",
                new
                {
                    controller = "SiteMenu",
                    action = "MenuContent",
                    page = UrlParameter.Optional,
                });

            routes.MapRoute("BlogContent", "{menuSlug}/{pageSlug}"
                , new
                {
                    controller = "SiteBlog",
                    action = "BlogContent",
                });

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
