namespace TeacherDesk.Models
{
    public interface IStorable
    {
        Guid Id { get; }
        DateTime CreatedAt { get; }
    }
}