using ExaminationSystem.DTO.Course;
using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Services.CourseStudents
{
    public interface ICourseStudentService
    {
        Task<IEnumerable<CourseStudentDTO>> Get(Expression<Func<CourseStudent, bool>> predicate);
        Task DeleteRange(IEnumerable<CourseStudentDTO> courseStudentDTOs);
        Task<int> Add(CourseStudentDTO courseStudentDTO);
    }
}
