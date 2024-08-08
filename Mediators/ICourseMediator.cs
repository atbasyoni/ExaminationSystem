using ExaminationSystem.DTO.Course;
using ExaminationSystem.ViewModels.Course;

namespace ExaminationSystem.Mediators
{
    public interface ICourseMediator
    {
        CourseDTO GetById(int id);
        IEnumerable<CourseDTO> GetAll();
        int AddCourse(CourseCreateDTO courseDTO);
        void EditCourse(CourseDTO courseDTO);
        void DeleteCourse(int id);
    }
}
