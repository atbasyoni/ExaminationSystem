namespace ExaminationSystem.DTO.Choice
{
    public class ChoiceDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionID { get; set; }
    }
}
