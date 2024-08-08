using ExaminationSystem.DTO.Course;
using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Services.CourseStudents
{
    public interface ICourseStudentService
    {
        IEnumerable<CourseStudentDTO> Get(Expression<Func<CourseStudent, bool>> predicate);
        void DeleteRange(IEnumerable<CourseStudentDTO> courseStudentDTOs);
    }
}
