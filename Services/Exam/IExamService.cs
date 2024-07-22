using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamService
    {
        int Add(ExamCreateViewModel viewModel);
    }
}
