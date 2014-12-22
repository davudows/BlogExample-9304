using BlogExample.Data.Orm;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogExample.UI.Web.Models
{
    public class BlogDetailModel
    {
        public Blog Blog {get; set;}

        public IPagedList<Blog> OtherBlogs { get; set; }
    }
}