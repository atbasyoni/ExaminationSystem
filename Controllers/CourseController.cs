using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.DTO.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators.Courses;
using ExaminationSystem.Models;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.ViewModels;
using ExaminationSystem.ViewModels.Course;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ResultViewModel<IEnumerable<CourseViewModel>>> GetAllCourses()
        {
            var courses = (await _courseMediator.GetAll()).AsQueryable().Map<CourseViewModel>();

            return new ResultViewModel<IEnumerable<CourseViewModel>>
            {
                IsSuccess = true,
                Data = courses,
            };
        }

        [HttpGet("{id}")]
        public async Task<ResultViewModel<CourseViewModel>> GetCourseByID(int id)
        {
            var course = (await _courseMediator.GetById(id)).MapOne<CourseViewModel>();

            return new ResultViewModel<CourseViewModel>
            {
                IsSuccess = true,
                Data = course,
            };
        }

        [Authorize("Instructor")]
        [HttpPost]
        public async Task<ResultViewModel<int>> CreateCourse(CourseCreateViewModel courseVM)
        {
            var courseDTO = courseVM.MapOne<CourseCreateDTO>();
            int courseId =  await _courseMediator.AddCourse(courseDTO);
            
            return new ResultViewModel<int>
            {
                IsSuccess = true,
                Data = courseId,
            };
        }

        [Authorize("Instructor")]
        [HttpPut]
        public async Task<ResultViewModel<bool>> EditCourse(CourseViewModel courseVM)
        {
            var courseDTO = courseVM.MapOne<CourseDTO>();
            await _courseMediator.EditCourse(courseDTO);

            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }

        [Authorize("Instructor")]
        [HttpDelete]
        public async Task<ResultViewModel<bool>> DeleteCourse(int id) 
        {
            await _courseMediator.DeleteCourse(id);
            
            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }

        [Authorize("Student")]
        [HttpPost]
        public ResultViewModel<bool> EnrollStudent(int studentId, CourseViewModel courseVM)
        {
            var courseDTO = courseVM.MapOne<CourseDTO>();
            _courseMediator.AssignStudentToCourse(studentId, );

            return new ResultViewModel<bool>
            {
                IsSuccess = true
            };
        }
    }
}
