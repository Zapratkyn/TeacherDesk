using System.Text.Json.Serialization;

/*
Represents a class of students. 
It has a name, an average age, and a list of courses. 
It belongs to a school.
Depending of the school's organization, it can be taught several courses, or just one
*/

namespace TeacherDesk.Models
{
    public class Class : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /*
        Average age can be set by the teacher when he adds it to his calendar
        It can be used to determine which sequences and resources are associated with the courses of the class, 
        as some content may be more suitable for certain ages.
        */
        public int AverageAge { get; set; }
        
        // The name of the class, e.g. "1A", "2B", etc.
        public required string Name { get; set; }
        
        public string? Notes { get; set; }
        public List<Guid> CoursesIds { get; set; } = new();
        public required Guid SchoolId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<ClassCourse>? Courses { get; set; }
        [JsonIgnore]
        public School? School { get; set; }
    }
}