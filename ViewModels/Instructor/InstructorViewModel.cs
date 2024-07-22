using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Instructors
{
    public class InstructorViewModel
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public string FullName => $"{FName} {LName}";
    }

    public static class InstructorViewModelExtensions
    {
        public static InstructorViewModel ToViewModel(this Instructor instructor)
        {
            return new InstructorViewModel
            {
                FName = instructor.FirstName,
                LName = instructor.LastName,
            };
        }

        public static IEnumerable<InstructorViewModel> ToViewModels(this IQueryable<Instructor> instructors) 
        {
            return instructors.Select(x => x.ToViewModel())
                .ToList();
        }
    }
}
