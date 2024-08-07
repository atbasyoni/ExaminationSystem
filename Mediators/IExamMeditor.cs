using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Mediators
{
    public interface IExamMeditor
    {
        IEnumerable<ExamViewModel> GetAll();
        ExamViewModel GetById(int id);
        void Add(ExamCreateViewModel examCreateVM);
        void Update(ExamViewModel examVM);
        void Delete(int id);
    }
}
