using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators;
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
        private readonly ICourseMediator _courseMediator;

        public CourseController(ICourseMediator courseMediator)
        {
            _courseMediator = courseMediator;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<CourseViewModel>> GetAllCourses()
        {
            var courses = _courseMediator.GetAll().AsQueryable().Map<CourseViewModel>();

            return new ResultViewModel<IEnumerable<CourseViewModel>>
            {
                IsSuccess = true,
                Data = courses,
            };
        }

        [HttpGet("{id}")]
        public ResultViewModel<CourseViewModel> GetCourseByID(int id)
        {
            var course = _courseMediator.GetById(id).MapOne<CourseViewModel>();

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
            int courseId = _courseMediator.AddCourse(courseDTO);
            
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
            _courseMediator.EditCourse(courseDTO);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCourse(int id) 
        {
            _courseMediator.DeleteCourse(id);
            return NoContent();
        }
    }
}
