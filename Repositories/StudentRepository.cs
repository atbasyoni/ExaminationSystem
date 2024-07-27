using ExaminationSystem.Data;
using ExaminationSystem.Models;

namespace ExaminationSystem.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(Context context) : base(context)
        {
        }
    }
}
