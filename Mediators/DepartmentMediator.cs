using AutoMapper;
using ExaminationSystem.DTO.Department;
using ExaminationSystem.Services.Departments;

namespace ExaminationSystem.Mediators
{
    public class DepartmentMediator : IDepartmentMediator
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentMediator(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public int AddDepartment(DepartmentCreateDTO departmentDTO)
        {
            int departmentId = _departmentService.Add(departmentDTO);

            return departmentId;
        }

        public void EditDepartment(DepartmentDTO departmentDTO)
        {
            _departmentService.Update(departmentDTO);
        }

        public void DeleteDepartment(int id)
        {
            var department = _departmentService.GetByID(id);

            if (department != null)
            {
                _departmentService.Delete(id);
            }
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
            return _departmentService.GetAll();
        }

        public DepartmentDTO GetById(int id)
        {
            return _departmentService.GetByID(id);
        }
    }
}
