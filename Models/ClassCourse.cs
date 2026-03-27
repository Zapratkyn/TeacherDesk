using System.Text.Json.Serialization;

/* 
Represents a course that is taught to a class. 
It has a type, a schedule, and a list of resources. 
It belongs to a class.
*/

namespace TeacherDesk.Models
{
    public class ClassCourse : IStorable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid ClassId { get; set; }

        /*
        The type of the course is used to determine which sequences and resources are associated with it.
        It can be used to browse a library of sequences and resources when the teacher wants to add new ones to the course.
        */
        public required CourseType? Type { get; set; }
        
        public string? Notes { get; set; }
        public Guid? CurrentSequenceId { get; set; }
        public Guid? CurrentLessonId { get; set; }

        /*
        The next and previous sequences and lessons are used to keep track of the progress of the course. 
        When the teacher marks a sequence or a lesson as completed, the next ones become the current ones.
        The next lessons are the ones in the current sequence
        If the current lesson is the one of the current sequence, the next sequence becomes the current one, and the next lessons become the current ones.
        */
        public List<Guid> NextSequencesIds { get; set; } = new();
        public List<Guid> NextLessonsIds { get; set; } = new();
        public List<Guid> PreviousSequencesIds { get; set; } = new(); // Archives of completed sequences
        public List<Guid> PreviousLessonsIds { get; set; } = new(); // Archives of completed lessons

        public List<Guid> ResourcesIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        /*
        The schedule is a list of course slots, which are the times when the course is taught to the class.
        It can also be compared to existing CourseSlots to warn the teacher of potential conflicts in his schedule.
        */
        public List<CourseSlot> Schedule { get; set; } = new();

        [JsonIgnore]
        public List<Resource>? Resources { get; set; }
        [JsonIgnore]
        public CourseSequence? CurrentSequence { get; set; }
        [JsonIgnore]
        public Lesson? CurrentLesson { get; set; }
        [JsonIgnore]
        public Class? Class { get; set; }
    }
}