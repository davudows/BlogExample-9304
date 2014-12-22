using BlogExample.Data.Dto.Admin;
using BlogExample.Data.Orm;
using BlogExample.Services.CacheServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlogExample.Services.DataServices
{
    public class AdminUserService : ServiceBase<AdminUser>, ICachable<AdminMenu>
    {
        private CacheService _cacheService;
        public AdminUserService()
        {
            _cacheService   = new CacheService();
        }
     
        public bool IsAuthory(int menuId, int userId)
        {
            bool isAuth = Db.AdminUserAuthories.Any(x => x.AdminId == userId && x.MenuId == menuId);
            return isAuth;
        }

        public AdminUser Login(string userName, string password)
        {
            AdminUser user = Db.AdminUsers.FirstOrDefault(e => e.UserName == userName && e.Password == password && !e.IsDeleted);
            return user;
        }

        public List<AdminUser> GetAll()
        {
            List<AdminUser> userList = Db.AdminUsers.Where(x => !x.IsDeleted).ToList();
            return userList;
        }

        public List<AdminMenu> GetMenusByAdmin(int adminId)
        {
            
            
           
            List<AdminMenu> adminMenu = _cacheService.GetFromCache("adminMenuList", this);
            List<AdminMenu> filteredList = adminMenu.Where(x=>x.AdminUserAuthories.Any(z=>z.AdminId==adminId)).OrderBy(a => a.SortOrder).ToList();
            return filteredList;
        }

        public override Types.DataRequestResult Insert(AdminUser entity)
        {
            //TODO Add admin to database
            throw new NotImplementedException();
        }

        public override Types.DataRequestResult Delete(int recordId)
        {
            throw new NotImplementedException();
        }

        public override Types.DataRequestResult Update(AdminUser entity)
        {
            throw new NotImplementedException();
        }

        public List<AdminAuthoryDto> GetAuthory(int adminId)
        {
            List<AdminAuthoryDto> authories = Db.AdminMenus.
                Select(
                x => new AdminAuthoryDto { 
                MenuId = x.Id,
                MenuName = x.Name,
                IsAuthory = x.AdminUserAuthories.Any(z=>z.AdminId==adminId)
                }

                ).ToList();
            return authories;

               
        }

        public void ChangeAuthory(int menuId , int adminId)
        {
            AdminUserAuthory authory = Db.AdminUserAuthories.FirstOrDefault(x=> x.MenuId == menuId && x.AdminId == adminId);

            if (authory!= null)
            {
                Db.AdminUserAuthories.Remove(authory);
                Db.SaveChanges();
            }
            else
            {
                authory = new AdminUserAuthory();
                authory.AdminId = adminId;
                authory.MenuId = menuId;
                Db.AdminUserAuthories.Add(authory);
                Db.SaveChanges();
            }
         
        }

        public List<AdminMenu> CallData()
        {
            return Db.AdminMenus.ToList();
        }

    }
}
