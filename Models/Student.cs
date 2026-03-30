namespace TeacherDesk.Models
{
    public class Student : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } 
        public string? Notes { get; set; }
        public Guid? ClassId { get; set; }
        public required Guid SchoolId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}