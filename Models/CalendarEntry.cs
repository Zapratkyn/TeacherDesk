namespace TeacherDesk.Models
{
    public enum CalendarEntryType
    {
        Lesson,
        NeedsSequence
    }

    public record CalendarEntry(
        ClassCourse Course,
        DateOnly Date,
        TimeOnly Time,
        CalendarEntryType Type,
        CourseLesson? CourseLesson,
        Guid CourseSequenceId,
        Guid SchoolId
    );
}