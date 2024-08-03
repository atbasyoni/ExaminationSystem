namespace ExaminationSystem.ViewModels.Exam
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int TotalQuestions { get; set; }
        public int TotalPoints { get; set; }

        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public ICollection<int> QuestionsIDs { get; set; }
    }
}