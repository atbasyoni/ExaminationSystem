using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamQuestionService
    {
        void Add(ExamQuestionCreateViewModel viewModel);
        void AddRange(int examId, IEnumerable<int> QuestionIDs);
    }
}