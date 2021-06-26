using Exam.Model.Entities;
using Exam.Model.Map;
using Microsoft.EntityFrameworkCore;

namespace Exam.Model.Context
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Map'leri import ediyoruz.
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            //Base'deki OnModelCreating'e modelBuilder'i gönderdik.
            base.OnModelCreating(modelBuilder);
        }

    }
}
