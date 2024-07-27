using ExaminationSystem.Data;
using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Models;

namespace ExaminationSystem.Repositories
{
    public class ChoiceRepository : Repository<Choice>
    {
        public ChoiceRepository(Context context) : base(context)
        {

        }
    }
}
