using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oz_DevBlog.DAL.Repository
{
    interface IRepository<T>:IDisposable where T:class
    {
        IQueryable<T> GetAllEntity();
        T GetEntityByID(int id);
        void InsertEntity(T Entity);
        void UpdateEntity(T Entity);
        void DeleteEntity(T Entity);
    }
}
