using System.Text.Json.Serialization;

namespace TeacherDesk.Models
{
    public class CourseLesson : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid CourseId { get; set; }
        public required Guid LessonId { get; set; }
        public bool IsPrepared { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public Course? Course { get; set; }
        [JsonIgnore]
        public Lesson? Lesson { get; set; }
    }
}