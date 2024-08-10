using ExaminationSystem.DTO.Course;

namespace ExaminationSystem.Services.Courses
{
    public interface ICourseService
    {
        Task<int> Add(CourseCreateDTO courseDTO);
        Task<IEnumerable<CourseDTO>> GetAll();
        Task<CourseDTO> GetByID(int id);
        Task Update(CourseDTO courseDTO);
        Task Delete(int id);
    }
}
