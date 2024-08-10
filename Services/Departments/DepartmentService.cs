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

        public async Task<int> Add(DepartmentCreateDTO departmentDTO)
        {
            var department = departmentDTO.MapOne<Department>();
            department = await _departmentRepository.AddAsync(department);

            await _departmentRepository.SaveChangesAsync();

            return department.Id;
        }

        public async Task Delete(int id)
        {
            var department = await _departmentRepository.GetByIDAsync(id);

            if (department == null) throw new KeyNotFoundException("Department not founnd!");

            _departmentRepository.Delete(department);
            await _departmentRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAll()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return departments.Map<DepartmentDTO>();
        }

        public async Task<DepartmentDTO> GetByID(int id)
        {
            var department = await _departmentRepository.GetByIDAsync(id);
            var departmentDTO = department.MapOne<DepartmentDTO>();

            return departmentDTO;
        }

        public async Task Update(DepartmentDTO departmentDTO)
        {
            var department = await _departmentRepository.GetByIDAsync(departmentDTO.Id);
            if (department == null) throw new KeyNotFoundException("Department not found!");

            department = departmentDTO.MapOne<Department>();
            _departmentRepository.Update(department);
            await _departmentRepository.SaveChangesAsync();
        }
    }
}
