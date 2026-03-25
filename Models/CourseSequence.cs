using System.Text.Json.Serialization;

namespace TeacherDesk.Models
{
    public class CourseSequence : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid CourseId { get; set; }
        public required Guid SequenceId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public Course? Course { get; set; }
        [JsonIgnore]
        public Sequence? Sequence { get; set; }
    }
}