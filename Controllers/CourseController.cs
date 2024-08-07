using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;

        public CourseController(IMapper mapper, ICourseService courseService)
        {
            _mapper = mapper;
            _courseService = courseService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<CourseViewModel>> GetAllCourses()
        {
            var courses = _courseService.GetAll().AsQueryable().ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider);

            return new ResultViewModel<IEnumerable<CourseViewModel>>
            {
                IsSuccess = true,
                Data = courses,
            };
        }

        [HttpGet("{id}")]
        public ResultViewModel<CourseViewModel> GetCourseByID(int id)
        {
            var course = _courseService.GetByID(id).MapOne<CourseViewModel>();

            return new ResultViewModel<CourseViewModel>
            {
                IsSuccess = true,
                Data = course,
            };
        }

        [HttpPost]
        public ResultViewModel<int> CreateCourse(CourseCreateViewModel courseVM)
        {
            var courseDTO = courseVM.MapOne<CourseCreateDTO>();
            int courseId = _courseService.Add(courseDTO);
            
            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = courseId,
            };
        }

        [HttpPut]
        public IActionResult EditCourse(CourseViewModel courseVM)
        {
            var courseDTO = courseVM.MapOne<CourseDTO>();
            _courseService.Update(courseDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCourse(int id) 
        {
            _courseService.Delete(id);
            return NoContent();
        }
    }
}
