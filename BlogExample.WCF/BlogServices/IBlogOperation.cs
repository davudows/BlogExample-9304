using BlogExample.Data.Orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.WCF.BlogServices
{
    [ServiceContract]
    public interface IBlogOperation
    {
        [OperationContract]
        List<Blog> GetAll();

        /// <summary>
        /// Girilen menünün slug'ına göre blogları getirir.
        /// </summary>
        /// <param name="pageSlug"></param>
        /// <returns></returns>
        
        [OperationContract]
        List<Blog> GetByMenuSlug(string pageSlug);
    }
}
