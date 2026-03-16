namespace TeacherDesk.Models
{
    public class Class : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int AverageAge { get; set; }
        public List<Course> Courses { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}