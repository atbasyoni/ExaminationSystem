using System.Collections.Generic;

namespace ExaminationSystem.Models
{
    public class Question : BaseModel
    {
        public Question()
        {
            Choices = new HashSet<Choice>();
        }

        public string Text { get; set; }
        public int Grade { get; set; }
        public HashSet<Choice> Choices { get; set; }

        public HashSet<ExamQuestion> ExamQuestions { get; set; }

    }
}
