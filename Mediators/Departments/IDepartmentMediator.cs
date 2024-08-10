using ExaminationSystem.DTO.Department;
using ExaminationSystem.ViewModels.Department;

namespace ExaminationSystem.Mediators.Departments
{
    public interface IDepartmentMediator
    {
        Task<IEnumerable<DepartmentDTO>> GetAll();
        Task<DepartmentDTO> GetById(int id);
        Task<int> AddDepartment(DepartmentCreateDTO departmentDTO);
        Task EditDepartment(DepartmentDTO departmentDTO);
        Task DeleteDepartment(int id);
    }
}
