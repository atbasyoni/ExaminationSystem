using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
            
            builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(5);

            builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(500);

            builder.Property(c => c.CreditHours)
            .IsRequired();

            builder.HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentID);

            builder.HasMany(c => c.CourseStudents)
                .WithOne(cs => cs.Course)
                .HasForeignKey(cs => cs.CourseID);

            builder.HasMany(c => c.CourseInstructors)
                .WithOne(ci => ci.Course)
                .HasForeignKey(ci => ci.CourseID);

            builder.HasMany(c => c.Exams)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseID);
        }
    }
}
