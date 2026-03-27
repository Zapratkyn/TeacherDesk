using System.Text.Json.Serialization;

/*
Represents a course a teacher can teach.
It has a type, a list of sequences, and a list of resources.
It is meant to be associated with a class through a ClassCourse
Reusable content that can be used in multiple classes.
*/

namespace TeacherDesk.Models
{
    public class Course : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /*
        The type of the course is used to determine which sequences and resources are associated with it.
        It can be used to browse a library of sequences and resources when the teacher wants to add new ones to the course.
        */
        public required CourseType Type { get; set; }
        
        /*
        The typical list of sequences used in this specific course.
        Standard content that can be used in multiple classes, but can be modified for a specific class through the ClassCourse.
        */
        public List<Guid> SequencesIds { get; set; } = new();

        /*
        A record of the ClassCourses that are associated with this course.
        It can be used to know which classes are using this course
        */
        public List<Guid> ClasseCoursesIds { get; set; } = new();
        
        public List<Guid> ResourcesIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Sequence>? Sequences { get; set; }
        [JsonIgnore]
        public List<Resource>? Resources { get; set; }
    }

    // TO EXPAND

    public enum CourseType
    {
        Français,
        Anglais,
        Histoire,
        Informatique
    }
}