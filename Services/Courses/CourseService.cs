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

        public async Task<int> Add(CourseCreateDTO courseDTO)
        {
            var course = courseDTO.MapOne<Course>();
            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();

            return course.Id;
        }

        public async Task Delete(int id)
        {
            var course = await _courseRepository.GetByIDAsync(id);

            if (course != null)
            {
                _courseRepository.Delete(course);
                await _courseRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            return (await _courseRepository.GetAllAsync()).Map<CourseDTO>();
        }

        public async Task<CourseDTO> GetByID(int id)
        {
            return (await _courseRepository.GetByIDAsync(id)).MapOne<CourseDTO>();
        }

        public async Task Update(CourseDTO courseDTO)
        {
            var course = await _courseRepository.GetByIDAsync(courseDTO.Id);

            if (course == null) throw new KeyNotFoundException("Course not found!");

            course = courseDTO.MapOne<Course>();
            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();
        }
    }
}
