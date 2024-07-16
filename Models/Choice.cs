using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class Choice
    {
        public int ID { get; set; }
        public string Text { get; set; }

        public bool IsRightAnswer { get; set; }

        //[ForeignKey("Question")]
        public int QuestionID { get; set; }
        public  Question Question { get; set; }

    }
}
