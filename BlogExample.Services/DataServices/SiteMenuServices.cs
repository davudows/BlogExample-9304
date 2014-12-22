using BlogExample.Data.Orm;
using BlogExample.Services.CacheServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogExample.Extensions;

namespace BlogExample.Services.DataServices
{
    public class SiteMenuServices : ServiceBase<SiteMenu>, ICachable<SiteMenu>
    {
        private CacheService _cacheService;

        public SiteMenuServices()
        {
            _cacheService = new CacheService();
        }

       

        public SiteMenu Find(int id)
        {
            return Db.SiteMenus.Find(id);
        }

   

        public List<SiteMenu> GetTopMenus()
        {

            List<SiteMenu> siteMenu = Db.SiteMenus.Where(x => !x.IsDeleted && x.TopMenuId == 0).OrderBy(x => x.SortOrder).ToList();
            return siteMenu;
        }

        public List<SiteMenu> GetAll()
        {
       
            List<SiteMenu> fromCache = _cacheService.GetFromCache("siteMenuList", this);
            List<SiteMenu> siteMenus = fromCache.Where(x => !x.IsDeleted  ).OrderBy(x => x.SortOrder).ToList();
            return siteMenus;
        }

        public List<SiteMenu> GetAllByLangId(int langId)
        {
            List<SiteMenu> siteMenus = Db.SiteMenus.Where(x => !x.IsDeleted && langId == x.LangId).ToList();

            return siteMenus;
        }

        public override Types.DataRequestResult Insert(SiteMenu entity)
        {
            if (!Db.Languages.Any(x => x.Id == entity.LangId))
            {

                return Error("Dil tespit edilemedi");
            }

            if (Db.SiteMenus.Any(x => x.Name == entity.Name))
            {
                return Error("Aynı isimde başka bir kayıt mevcut..!");
            }

            entity.PageSlug = entity.Name.ToClearString();
            entity.IsDeleted = false;
            entity.SortOrder = 9999;
            Db.SiteMenus.Add(entity);
            Db.SaveChanges();
            _cacheService.DeleteCache("siteMenuList");

            return Success("Menü başarıyla eklendi..!", entity);

        }

        public override Types.DataRequestResult Delete(int recordId)
        {
            SiteMenu menu = Db.SiteMenus.Find(recordId);
            menu.IsDeleted = true;
            Db.SaveChanges();
            _cacheService.DeleteCache("siteMenuList");
            return Success("");
        }

        public override Types.DataRequestResult Update(SiteMenu entity)
        {

            SiteMenu menu = Db.SiteMenus.Find(entity.Id);
            if (!Db.Languages.Any(x => x.Id == entity.LangId))
            {
                return Error("Dil tespit edilemedi");
            }

            if (Db.SiteMenus.Any(x => x.Name == entity.Name && x.Id != entity.Id))
            {
                return Error("Aynı isimde başka bir kayıt mevcuttur..!");
            }
            menu.PageSlug = entity.Name.ToClearString();
            menu.Name = entity.Name;
            menu.LangId = entity.LangId;
            menu.TopMenuId = entity.TopMenuId;
            Db.SaveChanges();
            _cacheService.DeleteCache("siteMenuList");
            return Success("Güncelleme başarılı", entity);
        }

        public List<SiteMenu> GetTopMenu(int langId)
        {

            List<SiteMenu> siteMenu = Db.SiteMenus.Where(x => !x.IsDeleted && x.TopMenuId == 0 && x.LangId == langId).OrderBy(x => x.SortOrder).ToList();
            return siteMenu;
        }


        public List<SiteMenu> CallData()
        {
            return Db.SiteMenus.Where(x => !x.IsDeleted).ToList();
        }
    }
}
