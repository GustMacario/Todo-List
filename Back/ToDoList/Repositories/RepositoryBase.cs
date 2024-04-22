using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Interfaces.Repositories;

namespace ToDoList.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public virtual void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        public virtual void Edit(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
