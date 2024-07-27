using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExaminationSystem.Data;
using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Exam;
using System.Linq;

namespace ExaminationSystem.Services.Exams
{
    public class ExamService : IExamService
    {
        private readonly IRepository<Exam> examRepository;
        private readonly IExamQuestionService examQuestionService;

        public ExamService(IRepository<Exam> examRepository, IExamQuestionService examQuestionService)
        {
            this.examRepository = examRepository;
            this.examQuestionService = examQuestionService;
        }

        public int Add(ExamCreateDTO examDTO)
        {
            var exam = examRepository.Add(new Exam
            {
                StartDate = examDTO.StartDate,
            });

            examRepository.SaveChanges();

            examQuestionService.AddRange(exam, examDTO.QuestionsIDs);

            return exam.ID;
        }

        public IEnumerable<ExamDTO> GetAll()
        {
            var exams = examRepository.GetAll();
            return exams.Map<ExamDTO>();
        }

        public ExamDTO GetByID(int examID)
        {
            var exam = examRepository.GetByID(examID);
            return exam.MapOne<ExamDTO>();
        }
    }
}