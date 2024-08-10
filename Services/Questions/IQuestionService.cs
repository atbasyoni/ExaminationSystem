using ExaminationSystem.DTO.Question;

namespace ExaminationSystem.Services.Questions
{
    public interface IQuestionService
    {
        Task<int> Add(QuestionCreateDTO questionCreateDTO);
        Task<QuestionDTO> GetByID(int id);
        Task Update(QuestionDTO questionDTO);
        Task Delete(int id);
    }
}
