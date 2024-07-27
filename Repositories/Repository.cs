using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> selector = null)
        {
            return GetAll().Where(predicate).Select(selector);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x => !x.IsDeleted).AsNoTrackingWithIdentityResolution();
        }

        public T GetByID(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
