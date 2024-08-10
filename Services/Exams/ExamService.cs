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

        public async Task<int> Add(ExamCreateDTO examDTO)
        {
            var exam = examDTO.MapOne<Exam>();

            exam = await _examRepository.AddAsync(exam);
            await _examRepository.SaveChangesAsync();

            return exam.Id;
        }

        public async Task Delete(int id)
        {
            var exam = await _examRepository.GetByIDAsync(id);
             _examRepository.Delete(exam);
            await _examRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamDTO>> GetAll()
        {
            return (await _examRepository.GetAllAsync()).Map<ExamDTO>();
        }

        public async Task<ExamDTO> GetByID(int examID)
        {
            return (await _examRepository.GetByIDAsync(examID)).MapOne<ExamDTO>();
        }

        public async Task Update(ExamDTO examDTO)
        {
            var exam = examDTO.MapOne<Exam>();

            if (exam != null)
            {
                _examRepository.Update(exam);
                await _examRepository.SaveChangesAsync();
            }
        }
    }
}