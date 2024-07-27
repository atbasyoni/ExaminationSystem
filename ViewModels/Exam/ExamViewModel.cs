namespace ExaminationSystem.ViewModels.Exam
{
    public class ExamViewModel
    {
        public DateTime StartDate { get; set; }
        public int NumberOfQuestions { get; set; }

        public string FirstQuestion { get; set; }

        public ICollection<int> QuestionsIDs { get; set; }
    }
}