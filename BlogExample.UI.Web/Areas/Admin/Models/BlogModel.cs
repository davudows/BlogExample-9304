using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogExample.UI.Web.Areas.Admin.Models
{
    public class BlogModel
    {
        [Required(ErrorMessage="Başlık boş geçilemez")]
        [MinLength(10,ErrorMessage="Başlık 10 karakterden az olamaz")]
        public string Title { get; set; }
        [Required(ErrorMessage="Açıklama boş geçilemez")]
        public string Description { get; set; }
        [Required(ErrorMessage="İçerik boş geçilemez")]

        public string Tags { get; set; }

        [AllowHtml]
        public string HtmlContent { get; set; }

        
    }
}