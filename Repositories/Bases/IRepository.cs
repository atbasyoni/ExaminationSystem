using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories.Bases
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIDAsync(int id);
        Task<T> GetWithTrackingByIDAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<T> First(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}
