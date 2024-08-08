using ExaminationSystem.DTO.Department;
using ExaminationSystem.ViewModels.Department;

namespace ExaminationSystem.Mediators
{
    public interface IDepartmentMediator
    {
        IEnumerable<DepartmentDTO> GetAll();
        DepartmentDTO GetById(int id);
        int AddDepartment(DepartmentCreateDTO departmentDTO);
        void EditDepartment(DepartmentDTO departmentDTO);
        void DeleteDepartment(int id);
    }
}
