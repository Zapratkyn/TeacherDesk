using System.Text.Json.Serialization;

namespace TeacherDesk.Models
{
    public class Exercise : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Instructions { get; set; } = string.Empty;
        public string Solution { get; set; } = string.Empty;
        public required ExerciseType Type { get; set; }
        public List<Guid> LessonsIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Lesson> Lessons { get; set; } = new();
    }

    public enum ExerciseType
    {
        Practical,
        QCM,
        Reflection,
        Research
    }

    public class QCM
    {
        public required string Question { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public int CorrectOptionIndex { get; set; }
    }
}