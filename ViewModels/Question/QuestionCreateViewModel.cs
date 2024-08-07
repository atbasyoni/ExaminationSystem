using ExaminationSystem.DTO.Choice;
using ExaminationSystem.Enums;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Exam
{
    public class QuestionCreateViewModel
    {
        public string Text { get; set; }
        public int Grade { get; set; }
        public string Difficulty { get; set; }

        public List<ChoiceCreateDTO> ChoiceDTOs { get; set; }
    }
}
