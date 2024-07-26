using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.ID);

            builder.Property(s => s.FirstName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(s => s.LastName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(s => s.Major)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.MajorID);

            builder.HasOne(s => s.Address)
              .WithMany(a => a.Students)
              .HasForeignKey(s => s.AddressID);

            builder.HasMany(c => c.CourseStudents)
                .WithOne(cs => cs.Student)
                .HasForeignKey(cs => cs.StudentID);
        }
    }
}
