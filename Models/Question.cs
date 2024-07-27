﻿using ExaminationSystem.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class Question : BaseModel
    {
        public string Text { get; set; }
        public int Grade { get; set; }
        public DifficultyLevel Difficulty { get; set; }

        public HashSet<Choice> Choices { get; set; }
        public HashSet<ExamQuestion> ExamQuestions { get; set; }
    }
}
