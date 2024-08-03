using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Courses;
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
        public ActionResult<IEnumerable<CourseViewModel>> GetAllCourses()
        {
            var courses = _courseService.GetAll();
            return Ok(courses.AsQueryable().ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider));
        }

        [HttpGet("{id}")]
        public ActionResult<CourseViewModel> GetCourseByID(int id)
        {
            var course = _courseService.GetByID(id);
            return Ok(course.MapOne<CourseViewModel>());
        }

        [HttpPost]
        public IActionResult CreateCourse(CourseCreateViewModel courseVM)
        {
            var courseDTO = courseVM.MapOne<CourseCreateDTO>();
            _courseService.Add(courseDTO);
            return NoContent();
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
