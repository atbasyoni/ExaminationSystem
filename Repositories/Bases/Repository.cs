using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories.Bases
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
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

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return (await GetAllAsync()).Where(predicate);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _context.Set<T>().Where(x => !x.IsDeleted).AsNoTrackingWithIdentityResolution();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            var queryable = await GetAllAsync();
            return await queryable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.SingleOrDefaultAsync(criteria);
        }

        public async Task<T> GetWithTrackingByIDAsync(int id)
        {
            return await _context.Set<T>()
                .Where(x => !x.IsDeleted && x.Id == id)
                .AsTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<T> First(Expression<Func<T, bool>> predicate)
        {
            return await (await GetAllAsync(predicate)).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
