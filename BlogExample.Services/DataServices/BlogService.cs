using BlogExample.Data.Orm;
using BlogExample.Services.CacheServices;
using BlogExample.Types;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Services.DataServices
{
    public class BlogService : ServiceBase<Blog>
    {

        public IPagedList<Blog> GetByCategory(string menuPageSlug,int page)
        {
            IPagedList<Blog> blogList = Db.Blogs.Where(x => !x.IsDeleted && x.IsActive && x.SiteMenu.PageSlug == menuPageSlug).OrderByDescending(x => x.AddDate).ToPagedList(page, 2);
            return blogList;
        }


        public List<Blog> GetAll()
        {

            List<Blog> blogList = Db.Blogs.Where(x => !x.IsDeleted).ToList();
            
            return blogList;
        }

        public Blog Find(int id)
        {
            Blog blog = Db.Blogs.Find(id);
            return blog;
        }

        public override DataRequestResult Insert(Blog entity)
        {
          
            entity.IsDeleted = false;
            entity.AddDate = DateTime.Now;
            Db.Blogs.Add(entity);
            Db.SaveChanges();
            return Success("Blogunuz başarıyla eklenmiştir.");
        }

        public override DataRequestResult Delete(int id)
        {
            Blog blog = Db.Blogs.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (blog == null)
            {
                return Error("Blog tespit edilemedi");
            }

            blog.IsDeleted = true;
            Db.SaveChanges();
            return Success("Blog başarıyla silindi..");
        }

        public override DataRequestResult Update(Blog entity)
        {
            Blog blog = Db.Blogs.Find(entity.Id);
            blog.Title = entity.Title;
            blog.Tag = entity.Tag;
            blog.LastUpdate = DateTime.Now;
            blog.IsActive = entity.IsActive;
            blog.ImagePath = entity.ImagePath;
            blog.BlogContent = entity.BlogContent;
            Db.SaveChanges();
            return Success("Blog başarıyla güncellenmiştir.");

        }

        public DataRequestResult SetActiveStatus(int id)
        {
            Blog blog = Db.Blogs.Find(id);
            blog.IsActive = !blog.IsActive;
            return Success(blog);
        }

        public Blog GetByPageSlug(string pageSlug)
        {
            Blog blog = Db.Blogs.FirstOrDefault(x => x.PageSlug == pageSlug);
            return blog;

        }


       
    }
}
