using System.Text.Json.Serialization;

/*
Represents a sequence that can be part of a course.
A sequence is a specific subject related to the course it is associated with.
It is made of multiple lessons
It has a title and description.
It is meant to be associated with a course through a CourseSequence
Reusable content that can be used in multiple courses.
*/

namespace TeacherDesk.Models
{
    public class Sequence : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;


        // One sequence could be used in several courses, even if the usual will be just one.
        public List<Guid> CoursesIds { get; set; } = new();

        /*
        The typical list of lessons used in this specific sequence.
        Standard content that can be used in multiple courses, but can be modified for a specific course through the CourseSequence.
        */
        public List<Guid> LessonsIds { get; set; } = new();

        public List<Guid> ResourcesIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Course>? Courses { get; set; }
        [JsonIgnore]
        public List<Lesson>? Lessons { get; set; }
        [JsonIgnore]
        public List<Resource>? Resources { get; set; }
    }
}