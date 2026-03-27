using System.Text.Json.Serialization;

/*
Represents a sequence that is part of a course taught to a class.
It has a reference to the course and the sequence.
It is a single occurence meant to be associated with a ClassCourse, which represents the fact that a course is taught to a class.
*/

namespace TeacherDesk.Models
{
    public class CourseSequence : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid CourseId { get; set; }
        public required Guid SequenceId { get; set; }
        public List<Guid>? LessonsIds { get; set; }
        public List<Guid>? ResourcesIds { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public CourseSequence? Course { get; set; }
        [JsonIgnore]
        public Sequence? Sequence { get; set; }
        [JsonIgnore]
        public List<Lesson>? Lessons { get; set; }
        [JsonIgnore]
        public List<Resource>? Resources { get; set; }
    }
}