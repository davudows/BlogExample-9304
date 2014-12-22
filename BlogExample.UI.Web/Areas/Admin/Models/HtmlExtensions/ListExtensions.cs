using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace BlogExample.UI.Web.Areas.Admin.Models.HtmlExtensions
{
    public static class ListExtensions
    {
        public static MvcHtmlString TopMenuType(this HtmlHelper helper, int topMenuId)
        {
            string menuType = topMenuId == 0 ? "Üst Menü" : "Alt Menü";
            return MvcHtmlString.Create(menuType);

        }

        public static MvcHtmlString DeleteButton(this HtmlHelper helper, string deleteAction,int recordId)
        {
            TagBuilder builder = new TagBuilder("img");

            builder.Attributes.Add("src", "/Areas/Admin/Content/images/delete-icon.png");
            builder.Attributes.Add("title", "Sil");
            builder.AddCssClass("deleteButton");
            builder.Attributes.Add("data-action", deleteAction);
            builder.Attributes.Add("data-recordid",recordId.ToString());
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));

        }

        public static MvcHtmlString EditButton(this HtmlHelper helper, string editAction)
        {
            TagBuilder aTag = new TagBuilder("a");
            aTag.Attributes.Add("href", editAction);
            TagBuilder imgTag = new TagBuilder("img");
            imgTag.Attributes.Add("src", "/Areas/Admin/Content/images/update-icon.png");
            imgTag.Attributes.Add("title", "Düzenle");
            aTag.InnerHtml = imgTag.ToString(TagRenderMode.SelfClosing);
            return new MvcHtmlString(aTag.ToString(TagRenderMode.Normal));
             
        }

    }
}