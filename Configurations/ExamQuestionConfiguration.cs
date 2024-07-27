using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Configurations
{
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            //builder.HasOne(eq => eq.Exam)
            //    .WithMany(e => e.ExamQuestions)
            //    .HasForeignKey(eq => eq.ExamID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(eq => eq.Question)
            //    .WithMany(q => q.ExamQuestions)
            //    .HasForeignKey(eq => eq.QuestionID)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
