namespace TeacherDesk.Models
{
    public class Lesson : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<Exercise> Exercises { get; set; } = new();
        public List<Sequence> Sequences { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}