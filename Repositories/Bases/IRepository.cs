using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories.Bases
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T GetByID(int id);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        T GetWithTrackinByID(int id);
        void SaveChanges();
    }
}
