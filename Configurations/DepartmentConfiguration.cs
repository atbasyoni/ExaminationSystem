using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.ID);

            builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(d => d.Code)
            .IsRequired()
            .HasMaxLength(5);

            builder.Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(500);

            builder.HasOne(d => d.HeadOfDepartment)
                .WithOne(i => i.Department)
                .HasForeignKey<Instructor>(d => d.DepartmentID);

            builder.HasMany(d => d.Courses)
                .WithOne(c => c.Department)
                .HasForeignKey(c => c.DepartmentID);

            builder.HasMany(d => d.Instructors)
                .WithOne(i => i.Department)
                .HasForeignKey(i => i.DepartmentID);

            builder.HasMany(d => d.Students)
                .WithOne(s => s.Major)
                .HasForeignKey(s => s.MajorID);
        }
    }
}
