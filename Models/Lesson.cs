namespace TeacherDesk.Models
{
    public class Lesson : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<Guid> Exercises { get; set; } = new();
        public List<Guid> Sequences { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}