using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            //builder.HasOne(ci => ci.Course)
            //    .WithMany(c => c.CourseInstructors)
            //    .HasForeignKey(ci => ci.CourseID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(ci => ci.Instructor)
            //    .WithMany(i => i.CourseInstructors)
            //    .HasForeignKey(ci => ci.InstructorID)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
