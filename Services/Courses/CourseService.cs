using ExaminationSystem.DTO.Course;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;

namespace ExaminationSystem.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public int Add(CourseCreateDTO courseDTO)
        {
            var course = courseDTO.MapOne<Course>();
            _courseRepository.Add(course);
            _courseRepository.SaveChanges();

            return course.Id;
        }

        public void Delete(int id)
        {
            var course = _courseRepository.GetByID(id);

            if (course != null)
            {
                _courseRepository.Delete(course);
                _courseRepository.SaveChanges();
            }
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return _courseRepository.GetAll().Map<CourseDTO>();
        }

        public CourseDTO GetByID(int id)
        {
            return _courseRepository.GetByID(id).MapOne<CourseDTO>();
        }

        public void Update(CourseDTO courseDTO)
        {
            var course = _courseRepository.GetByID(courseDTO.Id);

            if (course == null) throw new KeyNotFoundException("Course not found!");

            course = courseDTO.MapOne<Course>();
            _courseRepository.Update(course);
            _courseRepository.SaveChanges();
        }
    }
}
