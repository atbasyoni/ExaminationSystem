using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.ID);

            builder.Property(q => q.Text)
            .IsRequired()
            .HasMaxLength(200);

            builder.HasOne(q => q.CorrectAnswer)
                .WithOne(ca => ca.Question)
                .HasForeignKey<Question>(q => q.CorrectAnswerID);

            builder.HasMany(q => q.Choices)
                .WithOne(c => c.Question)
                .HasForeignKey(c => c.QuestionID);

            builder.HasMany(q => q.ExamQuestions)
                .WithOne(eq => eq.Question)
                .HasForeignKey(eq => eq.QuestionID);
        }
    }
}
