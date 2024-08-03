namespace ExaminationSystem.ViewModels.Question
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }
        public string Difficulty { get; set; }

        public ICollection<int> ChoiceIds { get; set; }
    }
}