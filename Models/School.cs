using System.Text.Json.Serialization;

namespace TeacherDesk.Models
{
    public class School : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; } = string.Empty;
        public required string Address { get; set; } = string.Empty;
        public List<Guid> ClassesIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Class> Classes { get; set; } = new();
    }
}