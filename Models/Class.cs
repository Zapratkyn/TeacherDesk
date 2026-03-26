using System.Text.Json.Serialization;

namespace TeacherDesk.Models
{
    public class Class : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int AverageAge { get; set; }
        public List<Guid> CoursesIds { get; set; } = new();
        public required Guid SchoolId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Course> Courses { get; set; } = new();
        [JsonIgnore]
        public School? School { get; set; }
    }
}