using BlogExample.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Services.UploadServices
{
    public class FileUploadResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public string FilePath { get; set; }

        public JsonResponse ToJson()
        {
            return new JsonResponse()
            {
                CssClass = IsSuccess ? "alert alert-info" : "alert alert-danger",
                Message = this.Message,
                
            };

        }

    }
}
