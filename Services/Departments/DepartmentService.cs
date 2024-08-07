using AutoMapper;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.DTO.Department;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int Add(DepartmentCreateDTO departmentDTO)
        {
            var department = departmentDTO.MapOne<Department>();
            department = _departmentRepository.Add(department);

            _departmentRepository.SaveChanges();

            return department.Id;
        }

        public void Delete(int id)
        {
            var department = _departmentRepository.GetByID(id);

            if (department == null) throw new KeyNotFoundException("Department not founnd!");

            _departmentRepository.Delete(department);
            _departmentRepository.SaveChanges();
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return departments.Map<DepartmentDTO>();
        }

        public DepartmentDTO GetByID(int id)
        {
            var department = _departmentRepository.GetByID(id);
            var departmentDTO = department.MapOne<DepartmentDTO>();

            return departmentDTO;
        }

        public void Update(DepartmentDTO departmentDTO)
        {
            var department = _departmentRepository.GetByID(departmentDTO.Id);
            if (department == null) throw new KeyNotFoundException("Department not found!");

            department = departmentDTO.MapOne<Department>();
            _departmentRepository.Update(department);
            _departmentRepository.SaveChanges();
        }
    }
}
