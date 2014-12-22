using BlogExample.Data.Orm;
using BlogExample.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Services.DataServices
{
    public abstract class ServiceBase<T> : IDisposable
    {

        protected BlogExampleEntities Db;
        protected ServiceBase()
        {
            Db = new BlogExampleEntities();

        }


        public abstract DataRequestResult Insert(T entity);

        

        public abstract DataRequestResult Delete(int recordId);

        public abstract DataRequestResult Update(T entity);

        private bool _disposed = false;

        public DataRequestResult Success(string message)
        {
            DataRequestResult result = new DataRequestResult();
            result.Message = message;
            result.IsSuccess = true;
            result.Id = null;
            return result;
        }
      
        public DataRequestResult Success(string message, object record)
        {
            DataRequestResult result = new DataRequestResult();
            result.Message = message;
            result.IsSuccess = true;
            result.Id = null;
            result.Record = record;
            return result;
        }
        public DataRequestResult Success(string message, int recordId)
        {
            DataRequestResult result = new DataRequestResult
            {
                Message = message,
                IsSuccess = true,
                Id = recordId,
            };
            return result;
        }

        public DataRequestResult Success(object record)
        {
            DataRequestResult result = new DataRequestResult
            {
                IsSuccess = true,
                Record = record,
            };
            return result;
        }

        public DataRequestResult Success(string message, int recordId, object record)
        {
            DataRequestResult result = new DataRequestResult
            {
                Message = message,
                IsSuccess = true,
                Id = recordId,
                Record = record,
            };
            return result;
        }

        public DataRequestResult Error(string message)
        {
            return new DataRequestResult
            {
                IsSuccess = false,
                Id = null,
                Message = message,
            };

        }

        public DataRequestResult Error(string message, int recordId)
        {
            return new DataRequestResult
            {
                Message = message,
                IsSuccess = false,
                Id = recordId,
            };
        }

        protected virtual void Dispose(bool disposed)
        {
            if (!disposed)
            {
                Db.Dispose();
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
