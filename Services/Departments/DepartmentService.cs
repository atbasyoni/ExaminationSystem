using ExaminationSystem.DTO.Course;
using ExaminationSystem.DTO.Department;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public int Add(DepartmentCreateDTO departmentDTO)
        {
            var department = departmentDTO.MapOne<Department>();

            departmentRepository.Add(department);
            departmentRepository.SaveChanges();

            return department.ID;
        }

        public void Delete(int id)
        {
            var department = departmentRepository.GetByID(id);
            departmentRepository.Delete(department);
            departmentRepository.SaveChanges();
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
            var departments = departmentRepository.GetAll();
            return departments.Map<DepartmentDTO>();
        }

        public DepartmentDTO GetByID(int id)
        {
            var department = departmentRepository.GetByID(id);
            var departmentDTO = department.MapOne<DepartmentDTO>();

            return departmentDTO;
        }

        public void Update(DepartmentDTO departmentDTO)
        {
            var department = departmentDTO.MapOne<Department>();
            departmentRepository.Update(department);
            departmentRepository.SaveChanges();
        }
    }
}
