using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> selector = null);
        T GetByID(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
