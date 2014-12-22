using BlogExample.Data.Orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Services.DataServices
{
   public class LanguageService :ServiceBase<Language>
    {
       public List<Language> GetAll()
       {
           List<Language> langList = Db.Languages.ToList();
           return langList;
       }

        public override Types.DataRequestResult Insert(Language entity)
        {
            throw new NotImplementedException();
        }

        public override Types.DataRequestResult Delete(int recordId)
        {
            throw new NotImplementedException();
        }

        public override Types.DataRequestResult Update(Language entity)
        {
            throw new NotImplementedException();
        }
    }
}
