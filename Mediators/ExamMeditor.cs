using ExaminationSystem.DTO.Exam;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.Mediators
{
    public class ExamMeditor : IExamMeditor
    {
        //public int Add(ExamCreateDTO examDTO)
        //{
        //    var exam = examDTO.MapOne<Exam>();

        //    exam = _examRepository.Add(exam);

        //    if (examDTO.QuestionsIDs != null)
        //    {
        //        _examQuestionService.AddRange(exam.Id, examDTO.QuestionsIDs);
        //    }

        //    return exam.Id;
        //}
        public void Add(ExamCreateViewModel examCreateVM)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExamViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ExamViewModel examVM)
        {
            throw new NotImplementedException();
        }
    }
}
