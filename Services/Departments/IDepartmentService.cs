using ExaminationSystem.DTO.Course;
using ExaminationSystem.DTO.Department;

namespace ExaminationSystem.Services.Departments
{
    public interface IDepartmentService
    {
        Task<int> Add(DepartmentCreateDTO departmentDTO);
        Task<IEnumerable<DepartmentDTO>> GetAll();
        Task<DepartmentDTO> GetByID(int id);
        Task Update(DepartmentDTO departmentDTO);
        Task Delete(int id);
    }
}
