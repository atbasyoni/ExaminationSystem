using ExaminationSystem.DTO.Question;

namespace ExaminationSystem.Mediators.Questions
{
    public interface IQuestionMediator
    {
        Task<QuestionDTO> GetById(int id);
        Task<int> AddQuestion(QuestionCreateDTO questionDTO);
        Task DeleteQuestion(int id);
        Task EditQuestion(QuestionDTO questionDTO);
    }
}
