using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Types
{
    public class DataRequestResult
    {
        public int? Id { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public object Record { get; set; }

        public JsonResponse ToJson()
        {
            JsonResponse response = new JsonResponse
            {
                Id = this.Id,
                CssClass = this.IsSuccess ? "alert alert-info" : "alert alert-danger",
                Message = this.Message,
                Record = this.Record,
                IsSuccess = this.IsSuccess,
            };
            return response;
        }
    }
}
