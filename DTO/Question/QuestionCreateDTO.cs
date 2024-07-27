using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Enums;
using ExaminationSystem.Models;

namespace ExaminationSystem.DTO.Question
{
    public class QuestionCreateDTO
    {
        public string Text { get; set; }
        public int Grade { get; set; }
        public DifficultyLevel Difficulty { get; set; }

        public List<ChoiceDTO> Choics { get; set; }
    }
}
