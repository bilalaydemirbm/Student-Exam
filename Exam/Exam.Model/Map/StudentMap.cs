using Exam.Core.Map;
using Exam.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Model.Map
{
    public class StudentMap : CoreMap<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Class).IsRequired(false);
            builder.Property(x => x.Department).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(80);
            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.isAdmin).IsRequired(true);
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Phone).IsRequired(false).HasMaxLength(12);
            builder.Property(x => x.Status).IsRequired(true);
            builder.Property(x => x.ProfileImageURL).IsRequired(false);
            builder.Property(x => x.ProfileBacgroundImageURL).IsRequired(false);
            base.Configure(builder);
        }
    }
}
