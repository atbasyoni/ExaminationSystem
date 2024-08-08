using ExaminationSystem.DTO.ExamQuestion;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.ViewModels.Exam;
using System.Linq.Expressions;

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

        public IEnumerable<ExamQuestionDTO> Get(Expression<Func<ExamQuestion, bool>> predicate)
        {
            IEnumerable<ExamQuestion> examQuestions = _examQuestionRepository.GetAll(predicate).ToList();
            return examQuestions.AsQueryable().Map<ExamQuestionDTO>();
        }

        public void DeleteRange(IEnumerable<ExamQuestionDTO> examQuestionDTOs)
        {
            var examQuestions = examQuestionDTOs.AsQueryable().Map<ExamQuestion>();
            _examQuestionRepository.DeleteRange(examQuestions);
        }
    }
}