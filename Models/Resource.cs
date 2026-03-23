using System.Text.Json.Serialization;

namespace TeacherDesk.Models
{
    public class Resource : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; } = string.Empty;
        public required string Url { get; set; } = string.Empty;
        public required ResourceType Type { get; set; }
        public List<Guid> CoursesIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Course> Courses { get; set; } = new();

        public enum ResourceType
        {
            Video,
            Article,
            Book,
            Website
        }
    }
}