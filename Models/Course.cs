using System.Text.Json.Serialization;

namespace TeacherDesk.Models
{
    public class Course : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required CourseType? Type { get; set; }
        public List<Guid> ClassesIds { get; set; } = new();
        public List<Guid> SequencesIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Sequence> Sequences { get; set; } = new();
        [JsonIgnore]
        public List<Class> Classes { get; set; } = new();
    }

    public enum CourseType
    {
        Français,
        Anglais,
        Histoire,
        Informatique
    }
}