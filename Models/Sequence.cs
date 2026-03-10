namespace TeacherDesk.Models
{
    public class Sequence : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Lesson> Lessons { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}