namespace TeacherDesk.Models
{
    public enum CalendarEntryType
    {
        Lesson,
        NeedsSequence
    }

    public record CalendarEntry(
        Course Course,
        DateOnly Date,
        TimeOnly Time,
        CalendarEntryType Type,
        CourseLesson? CourseLesson = null,
        Lesson? Lesson = null
    );
}