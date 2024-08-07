using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Users;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories.Users
{
    public class UserRepository<T> : IUserRepository<T> where T : User
    {
        private readonly Context _context;

        public UserRepository(Context context)
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

        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }

            _context.Set<T>().UpdateRange(entities);
        }


        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x => !x.IsDeleted);
        }

        public T GetByID(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}