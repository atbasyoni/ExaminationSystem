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

        public async Task<IEnumerable<CourseStudentDTO>> Get(Expression<Func<CourseStudent, bool>> predicate)
        {
            IEnumerable<CourseStudent> courseStudents = (await _repository.GetAllAsync(predicate)).ToList();
            return courseStudents.AsQueryable().Map<CourseStudentDTO>();
        }

        public async Task DeleteRange(IEnumerable<CourseStudentDTO> courseStudentDTOs)
        {
            var courseStudents = courseStudentDTOs.AsQueryable().Map<CourseStudent>();
            _repository.DeleteRange(courseStudents);
            await _repository.SaveChangesAsync();
        }

        public async Task<int> Add(CourseStudentDTO courseStudentDTO)
        {
            var courseStudent = courseStudentDTO.MapOne<CourseStudent>();

            await _repository.AddAsync(courseStudent);
            await _repository.SaveChangesAsync();

            return courseStudent.Id;
        }
    }
}
