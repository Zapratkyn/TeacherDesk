using TeacherDesk.Models;

namespace TeacherDesk.Models
{
    public class Lesson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<Exercise> Exercises { get; set; } = new();
        public int Order { get; set; }
    }
}