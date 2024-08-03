using ExaminationSystem.DTO.Course;

namespace ExaminationSystem.Services.Courses
{
    public interface ICourseService
    {
        CourseDTO Add(CourseCreateDTO courseDTO);
        IEnumerable<CourseDTO> GetAll();
        CourseDTO GetByID(int id);
        void Update(CourseDTO courseDTO);
        void Delete(int id);
    }
}
