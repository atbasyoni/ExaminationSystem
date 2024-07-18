using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public class InstructorRepository
    {
        public IQueryable<Instructor> GetAll()
        {
            Context context = new Context();

            IQueryable<Instructor> query = context.Instructors;

            return query;
        }

        public IQueryable<Instructor> Get(Expression<Func<Instructor, bool>> predicate)
        {
            Context context = new Context();

            return context.Instructors.Where(predicate);
        }

        public IQueryable<TResult> Get<TResult>(Expression<Func<Instructor, bool>> predicate,
            Expression<Func<Instructor, TResult>> selector)
        {
            Context context = new Context();

            return context.Instructors
                .Where(predicate)
                .Select(selector);
        }

        public Instructor GetByID(int id) 
        {
            Context context = new Context();

            var instructor = context.Instructors.FirstOrDefault(x => x.ID == id);

            return instructor;
        }
    }
}
