﻿namespace ExaminationSystem.ViewModels.Choices
{
    public class ChoiceViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionID { get; set; }
    }
}
