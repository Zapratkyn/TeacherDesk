namespace TeacherDesk.Models
{
    public class Sequence : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public List<Course> Courses { get; set; } = new();
        public List<Lesson> Lessons { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}