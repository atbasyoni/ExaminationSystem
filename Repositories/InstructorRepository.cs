using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public class InstructorRepository : Repository<Instructor>
    {
        public InstructorRepository(Context context) : base(context) { }

    }
}
