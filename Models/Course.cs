using System.Text.Json.Serialization;

namespace TeacherDesk.Models
{
    public class Course : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid ClassId { get; set; }
        public required CourseType? Type { get; set; }
        public List<Guid> SequencesIds { get; set; } = new();
        public List<CourseSlot> Schedule { get; set; } = new();
        public List<Guid> ResourcesIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Sequence> Sequences { get; set; } = new();
        [JsonIgnore]
        public List<Resource> Resources { get; set; } = new();
        [JsonIgnore]
        public Class? Class { get; set; }
    }

    public enum CourseType
    {
        Français,
        Anglais,
        Histoire,
        Informatique
    }
}