using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamQuestionService
    {
        void Add(ExamQuestionCreateViewModel viewModel);
        void AddRange(int examID, IEnumerable<int> QIDs);
    }
}
