using System.Text.Json.Serialization;

/*
Represents a lesson that is part of a sequence.
It has a reference to the sequence and the lesson.
It is a single occurence meant to be associated with a ClassCourse, which represents the fact that a course is taught to a class.
*/

namespace TeacherDesk.Models
{
    public class CourseLesson : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid CourseId { get; set; }
        // public required Guid CourseSequenceId { get; set; }
        public required Guid LessonId { get; set; }
        public List<Guid>? ResourcesIds { get; set; }
        public string? Notes { get; set; }
        public bool IsPrepared { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public Course? Course { get; set; }
        [JsonIgnore]
        public CourseSequence? Sequence { get; set; }
        [JsonIgnore]
        public Lesson? Lesson { get; set; }
        [JsonIgnore]
        public List<Resource>? Resources { get; set; }
    }
}