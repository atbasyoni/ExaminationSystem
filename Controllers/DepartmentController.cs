using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Department;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Departments;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<DepartmentViewModel>> GetAllDepartments()
        {
            var departments = _departmentService.GetAll().AsQueryable().ProjectTo<DepartmentViewModel>(_mapper.ConfigurationProvider);

            return new ResultViewModel<IEnumerable<DepartmentViewModel>>
            {
                IsSuccess = true,
                Data = departments,
            };
        }

        [HttpGet("{id}")]
        public ResultViewModel<DepartmentViewModel> GetDepartmentByID(int id)
        {
            var department = _departmentService.GetByID(id).MapOne<DepartmentViewModel>();

            return new ResultViewModel<DepartmentViewModel>
            {
                IsSuccess = true,
                Data = department,
            };
        }

        [HttpPost]
        public ResultViewModel<int> CreateDepartment(DepartmentCreateViewModel departmentVM)
        {
            var departmentCreateDTO = departmentVM.MapOne<DepartmentCreateDTO>();
            var departmentDTO =  _departmentService.Add(departmentCreateDTO);
            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data =  departmentDTO.Id,
            };
        }

        [HttpPut]
        public IActionResult EditDepartment(DepartmentViewModel departmentVM)
        {
            var departmentDTO = departmentVM.MapOne<DepartmentDTO>();
            _departmentService.Update(departmentDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            _departmentService.Delete(id);
            return Ok();
        }
    }
}
