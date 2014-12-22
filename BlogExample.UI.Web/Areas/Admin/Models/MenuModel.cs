using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogExample.UI.Web.Areas.Admin.Models
{
    public class MenuModel
    {
        [Display(Name="İsim")]
        [Required]
        public string Name { get; set; }

        public int? TopMenuId { get; set; }
  
        [Display(Name="Dil Seçiniz")]
        public int LangId { get; set; }
    }
}