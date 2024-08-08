using ExaminationSystem.DTO.Question;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Question;

namespace ExaminationSystem.Mediators
{
    public interface IQuestionMediator
    {
        public QuestionDTO GetById(int id);
        public int AddQuestion(QuestionCreateDTO questionDTO);
        public void EditQuestion(QuestionDTO questionDTO);
        public void DeleteQuestion(int id);
    }
}
