using System.Text.Json.Serialization;

/*
Represents a lesson that can be part of a course.
A lesson is a specific hour of class related to the course it is associated with.
It is the smallest unit of content that can be associated with a course
It has a title, content, and a list of exercises and sequences.
It is meant to be associated with a course through a CourseLesson
Reusable content that can be used in multiple sequences.
*/

namespace TeacherDesk.Models
{
    public class Lesson : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        // One lesson could be used in several sequences, even if the usual will be just one.
        public List<Guid> SequencesIds { get; set; } = new();

        /*
        The typical list of exercises used in this specific lesson.
        Standard content that can be used in multiple courses, but can be modified for a specific course through the CourseLesson.
        */
        public List<Guid> ExercisesIds { get; set; } = new();
        
        public List<Guid> ResourcesIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Exercise>? Exercises { get; set; }
        [JsonIgnore]
        public List<Sequence>? Sequences { get; set; }
        [JsonIgnore]
        public List<Resource>? Resources { get; set; }
    }
}