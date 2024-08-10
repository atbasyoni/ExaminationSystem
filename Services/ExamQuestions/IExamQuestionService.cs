using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;
using System.Linq.Expressions;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamQuestionService
    {
        Task<IEnumerable<ExamQuestionDTO>> Get(Expression<Func<ExamQuestion, bool>> predicate);
        Task Add(ExamQuestionCreateViewModel viewModel);
        Task AddRange(int examId, IEnumerable<int> QuestionIDs);
        Task DeleteRange(IEnumerable<ExamQuestionDTO> examQuestionDTOs);
    }
}