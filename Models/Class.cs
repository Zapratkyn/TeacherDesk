namespace TeacherDesk.Models
{
    public class Class : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Year { get; set; }
        public List<Course> Classes { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}