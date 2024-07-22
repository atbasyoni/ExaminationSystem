namespace ExaminationSystem.ViewModels.Exam
{
    public class ExamCreateViewModel
    {
        public DateTime StartDate { get; set; }

        public ICollection<int> QuestionsIDs { get; set; }
    }
}
