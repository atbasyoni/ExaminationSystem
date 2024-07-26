using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.ID);

            builder.Property(i => i.FirstName)
            .IsRequired()
            .HasMaxLength(50);
            
            builder.Property(i => i.LastName)
            .IsRequired()
            .HasMaxLength(50);
            
            builder.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentID);

            builder.HasMany(i => i.CourseInstructors)
                .WithOne(ci => ci.Instructor)
                .HasForeignKey(ci => ci.InstructorID);

            builder.HasMany(i => i.Exams)
                .WithOne(e => e.Instructor)
                .HasForeignKey(e => e.InstructorID);
        }
    }
}
