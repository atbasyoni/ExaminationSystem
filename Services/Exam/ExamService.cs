using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Services.Exams
{
    public class ExamService : IExamService
    {
        IRepository<Exam> repository;
        IExamQuestionService examQuestionService;

        public ExamService(IRepository<Exam> repository, IExamQuestionService examQuestionService)
        {
            this.repository = repository;
            this.examQuestionService = examQuestionService;
        }
        public int Add(ExamCreateViewModel viewModel)
        {
            var exam = repository.Add(new Exam
            {
                StartDate = viewModel.StartDate,
            });

            repository.SaveChanges();

            examQuestionService.AddRange(exam.ID, viewModel.QuestionsIDs);

            return exam.ID;
        }
    }
}
