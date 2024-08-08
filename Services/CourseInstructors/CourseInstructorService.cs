using ExaminationSystem.DTO.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using System.Linq.Expressions;

namespace ExaminationSystem.Services.CourseInstructors
{
    public class CourseInstructorService : ICourseInstructorService
    {
        private readonly IRepository<CourseInstructor> _repository;

        public CourseInstructorService(IRepository<CourseInstructor> repository)
        {
            _repository = repository;
        }

        public IEnumerable<CourseInstructorDTO> Get(Expression<Func<CourseInstructor, bool>> predicate)
        {
            IEnumerable<CourseInstructor> courseInstructors = _repository.GetAll(predicate).ToList();
            return courseInstructors.AsQueryable().Map<CourseInstructorDTO>();
        }

        public void DeleteRange(IEnumerable<CourseInstructorDTO> courseInstructorDTOs)
        {
            var courseInstructors = courseInstructorDTOs.AsQueryable().Map<CourseInstructor>();
            _repository.DeleteRange(courseInstructors);
        }
    }
}
