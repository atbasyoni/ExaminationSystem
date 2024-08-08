using ExaminationSystem.DTO.Department;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentMediator _departmentMediator;

        public DepartmentController(IDepartmentMediator departmentMediator)
        {
            _departmentMediator = departmentMediator;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<DepartmentViewModel>> GetAllDepartments()
        {
            var departments = _departmentMediator.GetAll().AsQueryable().Map<DepartmentViewModel>();

            return new ResultViewModel<IEnumerable<DepartmentViewModel>>
            {
                IsSuccess = true,
                Data = departments,
            };
        }

        [HttpGet("{id}")]
        public ResultViewModel<DepartmentViewModel> GetDepartmentByID(int id)
        {
            var department = _departmentMediator.GetById(id).MapOne<DepartmentViewModel>();

            return new ResultViewModel<DepartmentViewModel>
            {
                IsSuccess = true,
                Data = department,
            };
        }

        [HttpPost]
        public ResultViewModel<int> CreateDepartment(DepartmentCreateViewModel departmentVM)
        {
            var departmentDTO = departmentVM.MapOne<DepartmentCreateDTO>();
            int departmentId = _departmentMediator.AddDepartment(departmentDTO);

            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = departmentId,
            };
        }

        [HttpPut]
        public IActionResult EditDepartment(DepartmentViewModel departmentVM)
        {
            var departmentDTO = departmentVM.MapOne<DepartmentDTO>();
            _departmentMediator.EditDepartment(departmentDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            _departmentMediator.DeleteDepartment(id);
            return NoContent();
        }
    }
}
