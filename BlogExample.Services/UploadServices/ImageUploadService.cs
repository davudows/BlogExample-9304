using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlogExample.Services.UploadServices
{
    public class ImageUploadService : UploadService
    {
        private List<string> _allowedExtensions;

        public static ImageUploadService CreateService(HttpPostedFileBase postedFile)
        {
            ImageUploadService uploadService = new ImageUploadService(postedFile);
            return uploadService;
        }

        private ImageUploadService(HttpPostedFileBase postedFile)
            : base(postedFile)
        {
            _allowedExtensions = new List<string>();
            _allowedExtensions.Add("png");
            _allowedExtensions.Add("jpg");
        }

        public override FileUploadResult Upload(string virtualPath, string fileName)
        {
            if (_allowedExtensions.Contains(base.FileExtension.ToLower()))
            {
                return base.Upload(virtualPath, fileName);
            }
            return new FileUploadResult
            {
                FilePath = null,
                IsSuccess = false,
                Message = String.Format("{0} uzantısına izin verilmiyor", base.FileExtension),

            };

        }

    }
}
