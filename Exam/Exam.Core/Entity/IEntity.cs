namespace Exam.Core.Entity
{
    public interface IEntity<T>
    {
        T ID { get; set; }
    }
}
