using BlogExample.Services.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.WCF.BlogServices
{
    public class BlogOperation:IBlogOperation
    {
       
        public List<Data.Orm.Blog> GetAll()
        {
            using (ServicePoint services = new ServicePoint())
            {
                return services.Blog.GetAll();
            }
        }

        public List<Data.Orm.Blog> GetByMenuSlug(string pageSlug)
        {
            using(ServicePoint services = new ServicePoint())
            {
                throw new NotFiniteNumberException();
            }
        }
    }
}
