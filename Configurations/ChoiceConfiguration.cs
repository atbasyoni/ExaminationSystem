using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
