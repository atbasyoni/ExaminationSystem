using ExaminationSystem.Enums;
using ExaminationSystem.Models;

namespace ExaminationSystem.DTO.Question
{
    public class QuestionDTO
    {
        public string Text { get; set; }
        public int Grade { get; set; }
        public DifficultyLevel Difficulty { get; set; }

        public ICollection<int> ChoiceIDs { get; set; }
    }
}
