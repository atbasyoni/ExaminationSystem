using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(i => i.FirstName)
            .IsRequired()
            .HasMaxLength(50);
            
            builder.Property(i => i.LastName)
            .IsRequired()
            .HasMaxLength(50);
            
            builder.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}
