using ExaminationSystem.DTO.Department;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators.Departments;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Department;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ResultViewModel<IEnumerable<DepartmentViewModel>>> GetAllDepartments()
        {
            var departments = (await _departmentMediator.GetAll()).AsQueryable().Map<DepartmentViewModel>();

            return new ResultViewModel<IEnumerable<DepartmentViewModel>>
            {
                IsSuccess = true,
                Data = departments,
            };
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel<DepartmentViewModel>> GetDepartmentByID(int id)
        {
            var department = (await _departmentMediator.GetById(id)).MapOne<DepartmentViewModel>();

            return new ResultViewModel<DepartmentViewModel>
            {
                IsSuccess = true,
                Data = department,
            };
        }

        [Authorize("Instructor")]
        [HttpPost]
        public async Task<ResultViewModel<int>> CreateDepartment(DepartmentCreateViewModel departmentVM)
        {
            var departmentDTO = departmentVM.MapOne<DepartmentCreateDTO>();
            int departmentId = await _departmentMediator.AddDepartment(departmentDTO);

            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = departmentId,
            };
        }

        [Authorize("Instructor")]
        [HttpPut]
        public async Task<ResultViewModel<bool>> EditDepartment(DepartmentViewModel departmentVM)
        {
            var departmentDTO = departmentVM.MapOne<DepartmentDTO>();
            await _departmentMediator.EditDepartment(departmentDTO);

            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }

        [Authorize("Instructor")]
        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteDepartment(int id)
        {
            await _departmentMediator.DeleteDepartment(id);
             
            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }
    }
}
