using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Services.CacheServices
{
    public interface ICachable<T>
    {
         List<T> CallData();
    }
}
