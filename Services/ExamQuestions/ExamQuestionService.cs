using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public class ExamQuestionService : IExamQuestionService
    {
        IRepository<ExamQuestion> repository;

        public ExamQuestionService(IRepository<ExamQuestion> repository)
        {
            this.repository = repository;
        }
        public void Add(ExamQuestionCreateViewModel viewModel)
        {
            var exam = repository.Add(new ExamQuestion
            {
                ExamID = viewModel.ExamID,
                QuestionID = viewModel.QuestionID,
            });

            repository.SaveChanges();
        }

        public void AddRange(Exam exam, IEnumerable<int> QuestionIDs)
        {
            int examID = exam.ID;

            foreach (int id in QuestionIDs)
            {
                repository.Add(new ExamQuestion
                {
                    ExamID = examID,
                    QuestionID = id,
                });
            }

            repository.SaveChanges();
        }
    }
}