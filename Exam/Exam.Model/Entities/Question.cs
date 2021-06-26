using Exam.Core.Entity;
using Exam.Core.Entity.Enums;

namespace Exam.Model.Entities
{
    public class Question : CoreEntity
    {
        public string Content { get; set; }
        public int Answer { get; set; }

        public Answer answer;
    }
}
