using ExaminationSystem.DTO.Exam;
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

        public async Task Add(ExamQuestionCreateViewModel viewModel)
        {
            var exam = await _examQuestionRepository.AddAsync(new ExamQuestion
            {
                ExamID = viewModel.ExamID,
                QuestionID = viewModel.QuestionID,
            });

            await _examQuestionRepository.SaveChangesAsync();
        }

        public async Task AddRange(int examId, IEnumerable<int> QuestionIDs)
        {
            foreach (int Id in QuestionIDs)
            {
                await _examQuestionRepository.AddAsync(new ExamQuestion
                {
                    ExamID = examId,
                    QuestionID = Id,
                });
            }
            await _examQuestionRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamQuestionDTO>> Get(Expression<Func<ExamQuestion, bool>> predicate)
        {
            IEnumerable<ExamQuestion> examQuestions = (await _examQuestionRepository.GetAllAsync(predicate)).ToList();
            return examQuestions.AsQueryable().Map<ExamQuestionDTO>();
        }

        public async Task DeleteRange(IEnumerable<ExamQuestionDTO> examQuestionDTOs)
        {
            var examQuestions = examQuestionDTOs.AsQueryable().Map<ExamQuestion>();
            _examQuestionRepository.DeleteRange(examQuestions);
            await _examQuestionRepository.SaveChangesAsync();
        }
    }
}