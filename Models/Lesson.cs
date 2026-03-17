using System.Text.Json.Serialization;

namespace TeacherDesk.Models
{
    public class Lesson : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<Guid> ExercisesIds { get; set; } = new();
        public List<Guid> SequencesIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Exercise> Exercises { get; set; } = new();
        [JsonIgnore]
        public List<Sequence> Sequences { get; set; } = new();
    }
}