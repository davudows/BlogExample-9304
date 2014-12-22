using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlogExample.Services.CacheServices
{
    public class CacheService
    {
        /// <summary>
        /// ICacheable'ı implement etmiş classlardan çalıştırılır.
        /// ICachable'ın tipine göre dönüş yapar
        /// </summary>
        /// <typeparam name="T">Cachelanecek nesne</typeparam>
        /// <param name="key">Ram üzerindeki isim</param>
        /// <param name="data">Çağırıldığı class(this)</param>
        /// <returns>ICacheable'ın generic değeri.</returns>
        public List<T> GetFromCache<T>(string key, ICachable<T> data)
        {
            List<T> cacheList = HttpRuntime.Cache.Get(key) as List<T>;
            if (cacheList == null)
            {
                cacheList = data.CallData();
                HttpContext.Current.Cache.Insert(key, cacheList);
            }
            return cacheList;

        }

       

        public void DeleteCache(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

    }
}
