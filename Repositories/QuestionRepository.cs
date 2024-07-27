using ExaminationSystem.Data;
using ExaminationSystem.Models;

namespace ExaminationSystem.Repositories
{
    public class QuestionRepository : Repository<Question>
    {
        public QuestionRepository(Context context) : base(context)
        {
        }
    }
}
