using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BlogExample.UI.Web.Areas.Admin.Models.HtmlExtensions
{
    public static class FormExtensions
    {
        public static MvcHtmlString SubmitButton(this HtmlHelper helper, string value)
        {

            TagBuilder builder = new TagBuilder("input");
            builder.Attributes.Add("type", "submit");
            builder.AddCssClass("btn btn-info");
            builder.Attributes.Add("value", value);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString BsTextBoxFor<TModel, TProperty>
            (this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {

            string validationMessage = helper.ValidationMessageFor(expression).ToString();
            string name = helper.DisplayNameFor(expression).ToString();
            string input = helper.TextBoxFor(expression, new { @class = "form-control", @placeholder = name }).ToString();

            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("form-group");
          
            builder.InnerHtml = String.Format("<label>{0}</label>{1}{2}",name,input,validationMessage);

            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }


        public static MvcHtmlString BsDropdownFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression,string viewDataName,string defaultName)
        {
            string name = helper.DisplayNameFor(expression).ToString();
            string dropDown = helper.DropDownListFor(expression, (IEnumerable<SelectListItem>)helper.ViewData[viewDataName], defaultName, new { @class = "form-control" }).ToString();
            string validationMessage = helper.ValidationMessageFor(expression).ToString();
            TagBuilder builder = new TagBuilder("div");

            builder.InnerHtml = String.Format("<label>{0}</label>{1}{2}",name,dropDown,validationMessage);
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

    }
}