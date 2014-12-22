using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogExample.UI.Web.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [MinLength(6,ErrorMessage="Şifre 6 karakterden küçük olamaz")]
        public string Password { get; set; }


    }
}