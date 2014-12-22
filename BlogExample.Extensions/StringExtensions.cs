using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt32(this string value)
        {
            int intValue = Convert.ToInt32(value);
            return intValue;
        }

        public static string ToClearString(this string value)
        {
            string retunValue = "";
            value = value.ToLower();
            retunValue = value.Replace('ç', 'c');
            retunValue = retunValue.Replace('ş', 's');
            retunValue = retunValue.Replace("#","sharp");
            retunValue = retunValue.Replace(" ", "-");
            retunValue = retunValue.Replace("%", "yuzde");
            retunValue = retunValue.Replace("ğ", "g");
            retunValue = retunValue.Replace("ı", "i");
            return retunValue;

        }

       
    }
}
