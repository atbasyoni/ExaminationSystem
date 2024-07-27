using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            //builder.HasOne(cs => cs.Course)
            //    .WithMany(c => c.CourseStudents)
            //    .HasForeignKey(cs => cs.CourseID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(cs => cs.Student)
            //    .WithMany(s => s.CourseStudents)
            //    .HasForeignKey(cs => cs.StudentID)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
