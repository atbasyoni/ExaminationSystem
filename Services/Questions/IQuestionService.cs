using ExaminationSystem.DTO.Question;

namespace ExaminationSystem.Services.Questions
{
    public interface IQuestionService
    {
        int Add(QuestionCreateDTO questionCreateDTO);
        QuestionDTO GetByID(int id);
        void Update(QuestionDTO questionDTO);
        void Delete(int id);
    }
}
