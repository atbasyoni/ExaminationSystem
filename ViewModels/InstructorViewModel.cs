namespace ExaminationSystem.ViewModels
{
    public class InstructorViewModel
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public string FullName => $"{FName} {LName}";
    }
}
