using System.Collections.Generic;

namespace ExaminationSystem.Models
{
    public class Question
    {
        public Question()
        {
            Choices = new HashSet<Choice>();
        }

        public int ID { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }
        public HashSet<Choice> Choices { get; set; }

        public HashSet<ExamQuestion> ExamQuestions { get; set; }

    }
}
