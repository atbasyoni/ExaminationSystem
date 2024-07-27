using ExaminationSystem.Data;
using ExaminationSystem.Models;

namespace ExaminationSystem.Repositories
{
    public class ExamRepository : Repository<Exam>
    {
        public ExamRepository(Context context) : base(context)
        {
        }
    }
}
