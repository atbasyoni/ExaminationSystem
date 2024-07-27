using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.Text)
            .IsRequired()
            .HasMaxLength(500);

            builder.Property(q => q.Grade)
               .IsRequired();
        }
    }
}
