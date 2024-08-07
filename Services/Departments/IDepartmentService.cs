using ExaminationSystem.DTO.Course;
using ExaminationSystem.DTO.Department;

namespace ExaminationSystem.Services.Departments
{
    public interface IDepartmentService
    {
        int Add(DepartmentCreateDTO departmentDTO);
        IEnumerable<DepartmentDTO> GetAll();
        DepartmentDTO GetByID(int id);
        void Update(DepartmentDTO departmentDTO);
        void Delete(int id);
    }
}
