using ExaminationSystem.DTO.Department;
using ExaminationSystem.Services.Departments;

namespace ExaminationSystem.Mediators.Departments
{
    public class DepartmentMediator : IDepartmentMediator
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentMediator(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<int> AddDepartment(DepartmentCreateDTO departmentDTO)
        {
            int departmentId = await _departmentService.Add(departmentDTO);

            return departmentId;
        }

        public async Task EditDepartment(DepartmentDTO departmentDTO)
        {
            await _departmentService.Update(departmentDTO);
        }

        public async Task DeleteDepartment(int id)
        {
            var department = await _departmentService.GetByID(id);

            if (department != null)
            {
                await _departmentService.Delete(id);
            }
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAll()
        {
            return await _departmentService.GetAll();
        }

        public async Task<DepartmentDTO> GetById(int id)
        {
            return await _departmentService.GetByID(id);
        }
    }
}
