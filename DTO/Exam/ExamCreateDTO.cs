namespace ExaminationSystem.DTO.Exam
{
    public class ExamCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }

        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public ICollection<int> QuestionsIDs { get; set; }
    }
}