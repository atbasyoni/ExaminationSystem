using ExaminationSystem.Data;
using ExaminationSystem.Models;

namespace ExaminationSystem.Repositories
{
    public class DepartmentRepository : Repository<Department>
    {
        public DepartmentRepository(Context context) : base(context)
        {
        }
    }
}
