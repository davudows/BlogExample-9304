using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogExample.UI.Web.Models
{
    public class MenuModel
    {
        public string Name { get; set; }

        public string PageSlug { get; set; }

        public List<MenuModel> SubMenus { get; set; }
    }
}