using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogExample.UI.Web.Areas.Admin.Models
{
    public static class CurrentUser
    {
      
       
        public static int Id
        {

            get
            {
                return Convert.ToInt32(HttpContext.Current.User.Identity.Name.Split(';')[0]);
               
            }
                
            
        }


        public static string Name
        {

            get
            {

                string userName = HttpContext.Current.User.Identity.Name.Split(';')[1];
                return userName;
            }
        }


        public static string Mail
        {
            get
            {
                string mailAdress = HttpContext.Current.User.Identity.Name.Split(';')[2];
                return mailAdress;
            }
        }

    }
}