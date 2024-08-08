using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;
using System.Linq.Expressions;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamQuestionService
    {
        void Add(ExamQuestionCreateViewModel viewModel);
        void AddRange(int examId, IEnumerable<int> QuestionIDs);
        IEnumerable<ExamQuestionDTO> Get(Expression<Func<ExamQuestion, bool>> predicate);
        void DeleteRange(IEnumerable<ExamQuestionDTO> examQuestionDTOs);
    }
}