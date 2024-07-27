using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
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
        }
    }
}
