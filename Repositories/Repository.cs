using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        Context _context;

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
            //_context.Set<T>().Remove(entity);
            entity.Deleted = true;
            Update(entity);
        }

        public void Delete(int id)
        {
            T entity = _context.Find<T>(id);
            Delete(entity);
        }

        public void HardDelete(int id)
        {
            //T entity = _context.Find<T>(id);
            //_context.Set<T>().Remove(entity);

            _context.Set<T>().Where(x => x.ID == id).ExecuteDelete();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x => !x.Deleted).AsNoTracking();
            //return _context.Set<T>().Where(x => !x.Deleted).AsNoTrackingWithIdentityResolution();
        }

        public T GetByID(int id)
        {
            //return _context.Find<T>(id);
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        public T GetWithTrackinByID(int id)
        {
            return _context.Set<T>()
                .Where(x => !x.Deleted && x.ID == id)
                .AsTracking()
                .FirstOrDefault();
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return Get(predicate).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
