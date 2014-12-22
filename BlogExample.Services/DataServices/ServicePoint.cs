using BlogExample.Services.UploadServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Services.DataServices
{
    public class ServicePoint : IDisposable
    {

        private BlogService _blogService;

        private AdminUserService _adminUserService;

        private LanguageService _languageService;

        private SiteMenuServices _siteMenuService;

       

        private List<IDisposable> _disposeList;

     

        public ServicePoint()
        {
            _disposeList = new List<IDisposable>();
        }

    

        public BlogService Blog
        {
            get
            {
                if (_blogService == null)
                {
                    _blogService = new BlogService();
                    _disposeList.Add(_blogService);
                }

                return _blogService;
            }

        }

        public AdminUserService AdminUser
        {
            get
            {
                if (_adminUserService == null)
                {
                    _adminUserService = new AdminUserService();
                    _disposeList.Add(_adminUserService);
                }

                return _adminUserService;
            }
        }

        public LanguageService Language
        {
            get
            {
                if (_languageService == null)
                {
                    _languageService = new LanguageService();
                    _disposeList.Add(_languageService);
                }
                return _languageService;
            }
        }

        public SiteMenuServices SiteMenu
        {
            get
            {
                if (_siteMenuService == null)
                {
                    _siteMenuService = new SiteMenuServices();
                    _disposeList.Add(_siteMenuService);
                }
                return _siteMenuService;
            }
        }


        private bool _disposed = false;

        private void Dispose(bool disposed)
        {
            if (!disposed)
            {
                foreach (var item in _disposeList)
                {
                    item.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(_disposed);
            GC.SuppressFinalize(this);
        }
    }
}
