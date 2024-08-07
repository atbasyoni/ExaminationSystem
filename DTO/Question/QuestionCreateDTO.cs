using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Enums;
using ExaminationSystem.Models;

namespace ExaminationSystem.DTO.Question
{
    public class QuestionCreateDTO
    {
        public string Text { get; set; }
        public int Grade { get; set; }
        public string Difficulty { get; set; }

        public List<ChoiceCreateDTO> ChoiceDTOs { get; set; }
    }
}
