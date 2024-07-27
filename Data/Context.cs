using ExaminationSystem.Configurations;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExaminationSystem.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }

           modelBuilder.ApplyConfiguration(new AddressConfiguration());
           modelBuilder.ApplyConfiguration(new ChoiceConfiguration());
           modelBuilder.ApplyConfiguration(new CourseConfiguration());
           modelBuilder.ApplyConfiguration(new CourseInstructorConfiguration());
           modelBuilder.ApplyConfiguration(new CourseStudentConfiguration());
           modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
           modelBuilder.ApplyConfiguration(new ExamConfiguration());
           modelBuilder.ApplyConfiguration(new ExamQuestionConfiguration());
           modelBuilder.ApplyConfiguration(new InstructorConfiguration());
           modelBuilder.ApplyConfiguration(new QuestionConfiguration());
           modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
