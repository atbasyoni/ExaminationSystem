using AutoMapper;
using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;

namespace ExaminationSystem.Services.Exams
{
    public class ExamService : IExamService
    {
        IRepository<Exam> _examRepository;

        public ExamService(IRepository<Exam> examRepository)
        {
            _examRepository = examRepository;
        }

        public int Add(ExamCreateDTO examDTO)
        {
            var exam = examDTO.MapOne<Exam>();

            exam = _examRepository.Add(exam);
            _examRepository.SaveChanges();

            return exam.Id;
        }

        public void Delete(int id)
        {
            var exam = _examRepository.GetByID(id);
             _examRepository.Delete(exam);
            _examRepository.SaveChanges();
        }

        public IEnumerable<ExamDTO> GetAll()
        {
            return _examRepository.GetAll().Map<ExamDTO>();
        }

        public ExamDTO GetByID(int examID)
        {
            return _examRepository.GetByID(examID).MapOne<ExamDTO>();
        }

        public void Update(ExamDTO examDTO)
        {
            var exam = examDTO.MapOne<Exam>();

            if (exam != null)
            {
                _examRepository.Update(exam);
                _examRepository.SaveChanges();
            }
        }
    }
}