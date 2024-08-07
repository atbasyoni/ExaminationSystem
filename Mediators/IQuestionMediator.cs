using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Question;

namespace ExaminationSystem.Mediators
{
    public interface IQuestionMediator
    {
        IEnumerable<QuestionViewModel> GetAll();
        QuestionViewModel GetById(int id);
        void Add(QuestionCreateViewModel questionCreateVM);
        void Update(QuestionViewModel questionVM);
        void Delete(int id);
    }
}
