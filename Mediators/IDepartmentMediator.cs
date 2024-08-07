using ExaminationSystem.ViewModels.Department;

namespace ExaminationSystem.Mediators
{
    public interface IDepartmentMediator
    {
        IEnumerable<DepartmentViewModel> GetAll();
        DepartmentViewModel GetById(int id);
        void Add(DepartmentCreateViewModel departmentCreateVM);
        void Update(DepartmentViewModel departmentVM);
        void Delete(int id);
    }
}
