using ExaminationSystem.Data;
using ExaminationSystem.Models;

namespace ExaminationSystem.Repositories
{
    public class CourseRepository : Repository<Course>
    {
        public CourseRepository(Context context) : base(context)
        {
        }
    }
}
