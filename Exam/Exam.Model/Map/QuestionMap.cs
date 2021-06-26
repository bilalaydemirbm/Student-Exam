using Exam.Core.Map;
using Exam.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Model.Map
{
    public class QuestionMap : CoreMap<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Content).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.Answer).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true);
            base.Configure(builder);
        }

    }
}
