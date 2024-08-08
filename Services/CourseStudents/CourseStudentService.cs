using ExaminationSystem.DTO.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using System.Linq.Expressions;
using System.Net;

namespace ExaminationSystem.Services.CourseStudents
{
    public class CourseStudentService : ICourseStudentService
    {
        private readonly IRepository<CourseStudent> _repository;

        public CourseStudentService(IRepository<CourseStudent> repository)
        {
            _repository = repository;
        }

        public IEnumerable<CourseStudentDTO> Get(Expression<Func<CourseStudent, bool>> predicate)
        {
            IEnumerable<CourseStudent> courseStudents = _repository.GetAll(predicate).ToList();
            return courseStudents.AsQueryable().Map<CourseStudentDTO>();
        }

        public void DeleteRange(IEnumerable<CourseStudentDTO> courseStudentDTOs)
        {
            var courseStudents = courseStudentDTOs.AsQueryable().Map<CourseStudent>();
            _repository.DeleteRange(courseStudents);
        }
    }
}
