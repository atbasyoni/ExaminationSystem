using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FirstName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(s => s.LastName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}
