using ExaminationSystem.DTO.Course;
using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Services.CourseInstructors
{
    public interface ICourseInstructorService
    {
        Task<IEnumerable<CourseInstructorDTO>> Get(Expression<Func<CourseInstructor, bool>> predicate);
        Task DeleteRange(IEnumerable<CourseInstructorDTO> courseInstructorDTOs);
    }
}
