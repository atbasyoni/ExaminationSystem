using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Enums;

namespace ExaminationSystem.ViewModels.Question
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }
        public string Difficulty { get; set; }

        public List<ChoiceDTO> ChoiceDTOs { get; set; }
    }
}