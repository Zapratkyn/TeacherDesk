namespace TeacherDesk.Models
{
    public class Course : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required CourseType Type { get; set; }
        public List<Class> Classes { get; set; } = new();
        public List<Sequence> Sequences { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public enum CourseType
    {
        Français,
        Anglais,
        Histoire,
        Informatique
    }
}