using ExaminationSystem.DTO.Question;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.Services.Choices;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Question;

namespace ExaminationSystem.Mediators
{
    public class QuestionMediator : IQuestionMediator
    {
        //public QuestionService(IRepository<Question> questionRepository, IChoiceService choiceService)
        //{
        //    _questionRepository = questionRepository;
        //    _choiceService = choiceService;
        //}

        //public int Add(QuestionCreateDTO questionCreateDTO)
        //{
        //    var question = questionCreateDTO.MapOne<Question>();

        //    question = _questionRepository.Add(question);

        //    if (questionCreateDTO.ChoiceDTOs != null)
        //    {
        //        _choiceService.AddRange(question.Id, questionCreateDTO.ChoiceDTOs);
        //    }

        //    return question.Id;
        //}

        //public void Delete(int id)
        //{
        //    var question = _questionRepository.GetWithTrackinByID(id);
        //    _questionRepository.Delete(question);

        //    _choiceService.DeleteRange(question.Choices);
        //}


        public void Add(QuestionCreateViewModel questionCreateVM)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public QuestionViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionViewModel questionVM)
        {
            throw new NotImplementedException();
        }
    }
}
