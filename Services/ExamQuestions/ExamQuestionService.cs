using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public class ExamQuestionService : IExamQuestionService
    {
        private readonly IRepository<ExamQuestion> _examQuestionRepository;

        public ExamQuestionService(IRepository<ExamQuestion> examQuestionRepository)
        {
            _examQuestionRepository = examQuestionRepository;
        }

        public void Add(ExamQuestionCreateViewModel viewModel)
        {
            var exam = _examQuestionRepository.Add(new ExamQuestion
            {
                ExamID = viewModel.ExamID,
                QuestionID = viewModel.QuestionID,
            });

            _examQuestionRepository.SaveChanges();
        }

        public void AddRange(int examId, IEnumerable<int> QuestionIDs)
        {
            foreach (int Id in QuestionIDs)
            {
                _examQuestionRepository.Add(new ExamQuestion
                {
                    ExamID = examId,
                    QuestionID = Id,
                });
            }

            _examQuestionRepository.SaveChanges();
        }
    }
}