using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Extensions
{
   public static class ObjectExtensions
    {
       public static int ToInt32(this object value)
       {
           int convertedValue = Convert.ToInt32(value);
           return convertedValue;
       }
    }
}
