using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories.Users
{
    public interface IUserRepository<T> where T : User
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T GetByID(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void SaveChanges();
    }
}