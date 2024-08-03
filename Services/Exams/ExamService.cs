using AutoMapper;
using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminationSystem.Services.Exams
{
    public class ExamService : IExamService
    {
        IRepository<Exam> _examRepository;
        IExamQuestionService _examQuestionService;
        IMapper _mapper;

        public ExamService(IRepository<Exam> examRepository, IExamQuestionService examQuestionService, IMapper mapper)
        {
            _examRepository = examRepository;
            _examQuestionService = examQuestionService;
            _mapper = mapper;
        }

        public int Add(ExamCreateDTO examDTO)
        {
            var exam = examDTO.MapOne<Exam>();

            exam = _examRepository.Add(exam);

            _examQuestionService.AddRange(exam.Id, examDTO.QuestionsIDs);

            return exam.Id;
        }

        public void Delete(int id)
        {
            var exam = _examRepository.GetByID(id);
             _examRepository.Delete(exam);
        }

        public IEnumerable<ExamDTO> GetAll()
        {
            return _examRepository.GetAll().ToList().AsQueryable().Map<ExamDTO>();
        }

        public ExamDTO GetByID(int examID)
        {
            return _examRepository.GetByID(examID).MapOne<ExamDTO>();
        }

        public void Update(ExamDTO examDTO)
        {
            throw new NotImplementedException();
        }
    }
}