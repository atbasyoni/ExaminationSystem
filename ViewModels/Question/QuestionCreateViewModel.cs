namespace ExaminationSystem.ViewModels.Exam
{
    public class QuestionCreateViewModel
    {
        public string Text { get; set; }
        public int Grade { get; set; }
        public string Difficulty { get; set; }

        public ICollection<int> ChoiceIds { get; set; }
    }
}
