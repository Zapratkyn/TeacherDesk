using System.Collections.ObjectModel;
using TeacherDesk.Models;

namespace TeacherDesk.ViewModels
{
    public partial class CalendarTestViewModel : ViewModelBase
    {
        public ObservableCollection<CalendarDayViewModel> Days { get; } = new();

        public CalendarTestViewModel()
        {
            var school = new School { Name = "Athénée Royal", Address = "Rue de la Loi 1, Bruxelles" };

            var group = new Class { SchoolId = school.Id, School = school };

            var lesson = new Lesson { Title = "Introduction aux algorithmes" };

            var courseInfo = new Course
            {
                ClassId = group.Id,
                Type = CourseType.Informatique,
                Class = group,
                Resources = new List<Resource>
                {
                    new Resource { Title = "Vidéo intro", Url = "https://example.com", Type = Resource.ResourceType.Video },
                    new Resource { Title = "Article MDN", Url = "https://mdn.com", Type = Resource.ResourceType.Article }
                }
            };

            var courseLesson = new CourseLesson
            {
                CourseId = courseInfo.Id,
                LessonId = lesson.Id,
                IsPrepared = false
            };

            var today = DateOnly.FromDateTime(DateTime.Today);

            var entries = new List<CalendarEntry>
            {
                new CalendarEntry(courseInfo, today, new TimeOnly(8, 0),  CalendarEntryType.Lesson, courseLesson, lesson),
                new CalendarEntry(courseInfo, today, new TimeOnly(10, 0), CalendarEntryType.Lesson, courseLesson, lesson),
                new CalendarEntry(courseInfo, today.AddDays(1), new TimeOnly(9, 0),  CalendarEntryType.NeedsSequence),
                new CalendarEntry(courseInfo, today.AddDays(4), new TimeOnly(11, 0), CalendarEntryType.Lesson, courseLesson, lesson),
            };

            var school2 = new School { Name = "Ecole Communale", Address = "Rue Jean Benaets 1, Bruxelles" };

            var group2 = new Class { SchoolId = school2.Id, School = school2 };

            var lesson2 = new Lesson { Title = "Les verbes irréguliers" };

            var courseInfo2 = new Course
            {
                ClassId = group2.Id,
                Type = CourseType.Anglais,
                Class = group2,
                Resources = new List<Resource>
                {
                    new Resource { Title = "Vidéo intro", Url = "https://example.com", Type = Resource.ResourceType.Video },
                    new Resource { Title = "Article MDN", Url = "https://mdn.com", Type = Resource.ResourceType.Article }
                }
            };

            var courseLesson2 = new CourseLesson
            {
                CourseId = courseInfo2.Id,
                LessonId = lesson2.Id,
                IsPrepared = false
            };

            var entries2 = new List<CalendarEntry>
            {
                new CalendarEntry(courseInfo2, today, new TimeOnly(11, 0),  CalendarEntryType.Lesson, courseLesson2, lesson2),
                new CalendarEntry(courseInfo2, today, new TimeOnly(14, 0), CalendarEntryType.Lesson, courseLesson2, lesson2),
                new CalendarEntry(courseInfo2, today.AddDays(1), new TimeOnly(13, 0),  CalendarEntryType.NeedsSequence),
                new CalendarEntry(courseInfo2, today.AddDays(5), new TimeOnly(11, 0), CalendarEntryType.Lesson, courseLesson2, lesson2),
            };

            var entriesCombined = entries.Concat(entries2);

            var grouped2 = entriesCombined
                .GroupBy(e => e.Date)
                .OrderBy(g => g.Key)
                .Select(g => new CalendarDayViewModel(
                    g.Key,
                    g.OrderBy(e => e.Time).Select(e => new CalendarEntryViewModel(e))
                ));

            foreach (var day in grouped2)
                Days.Add(day);
        }
    }
}