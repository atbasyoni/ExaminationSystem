using ExaminationSystem.DTO.Course;
using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Services.CourseInstructors
{
    public interface ICourseInstructorService
    {
        IEnumerable<CourseInstructorDTO> Get(Expression<Func<CourseInstructor, bool>> predicate);
        void DeleteRange(IEnumerable<CourseInstructorDTO> courseInstructorDTOs);
    }
}
