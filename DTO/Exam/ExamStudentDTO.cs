namespace ExaminationSystem.DTO.Exam
{
    public class ExamStudentDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }

        public List<ExamAnswerDTO> Answers { get; set; }
    }
}
