using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BlogExample.Extensions;
using System.IO;

namespace BlogExample.Services.UploadServices
{
    public class UploadService : IDisposable
    {
        protected HttpPostedFileBase _postedFile;

        protected string FileExtension
        {
            get;
            private set;

        }
        public UploadService(HttpPostedFileBase postedFile)
        {
            _postedFile = postedFile;

            string[] nameArray = _postedFile.FileName.Split('.');
            FileExtension = nameArray[nameArray.Length - 1];
        }


        public virtual FileUploadResult Upload(string virtualPath, string fileName)
        {
            string path = HttpContext.Current.Server.MapPath(virtualPath);

            string uniqFileName = CreateUniqName(fileName.ToClearString(), path);

            _postedFile.SaveAs(path + "/" + uniqFileName);
            return new FileUploadResult
            {
                FilePath = path + "/" + uniqFileName,
                IsSuccess = true,
                Message = "Upload işleminiz gerçekleşti",
            };

        }

        private string CreateUniqName(string fileName, string path)
        {
            string filePath = "";
            int i = 0;
            do
            {
                if (i == 0)
                    filePath = fileName + "." + FileExtension;
                else filePath = fileName + i + "." + FileExtension;
                ++i;
            } while (File.Exists(path +"\\" +filePath));
            return filePath;
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
