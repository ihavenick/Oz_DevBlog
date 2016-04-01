using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oz_DevBlog.DAL.Context;
using System.Data.Entity;

namespace Oz_DevBlog.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Oz_DevDBContext _context;
        private readonly DbSet<T> _dbset;
        public Repository()
        {
            _context = new Oz_DevDBContext();
            _dbset = _context.Set<T>();
        }
        public IQueryable<T> GetAllEntity()
        {
            return _dbset;
        }

        public T GetEntityByID(int id)
        {
            return _dbset.Find(id);
        }

        public void InsertEntity(T Entity)
        {
            _dbset.Add(Entity);
            _context.SaveChanges();
        }

        public void UpdateEntity(T Entity)
        {
            _dbset.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteEntity(T Entity)
        {
            _dbset.Remove(Entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
