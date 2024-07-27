using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(d => d.Code)
            .IsRequired()
            .HasMaxLength(5);

            builder.Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(500);
        }
    }
}
