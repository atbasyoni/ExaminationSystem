using ExaminationSystem.ViewModels.Course;

namespace ExaminationSystem.Mediators
{
    public interface ICourseMediator
    {
        IEnumerable<CourseViewModel> GetAll();
        CourseViewModel GetById(int id);
        void Add(CourseCreateViewModel courseCreateVM);
        void Update(CourseViewModel courseVM);
        void Delete(int id);
    }
}
