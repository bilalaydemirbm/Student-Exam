using Exam.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Core.Map
{
    public abstract class CoreMap<T> : IEntityTypeConfiguration<T> where T : CoreEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Status).IsRequired(true);
        }
    }
}
