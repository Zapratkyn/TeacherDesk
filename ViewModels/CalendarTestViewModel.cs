using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TeacherDesk.Models;

namespace TeacherDesk.ViewModels
{
    public partial class CalendarTestViewModel : ViewModelBase
    {
        public ObservableCollection<CalendarDayViewModel> ThisWeekDays { get; } = new();
        public ObservableCollection<CalendarDayViewModel> NextWeekDays { get; } = new();

        [ObservableProperty] private bool _isThisWeekExpanded = true;
        [ObservableProperty] private bool _isNextWeekExpanded = false;

        public CalendarTestViewModel()
        {
            var school = new School { Name = "Athénée Royal", Address = "Rue de la Loi 1, Bruxelles" };
            var school2 = new School { Name = "Ecole Communale", Address = "Rue Jean Benaets 1, Bruxelles" };

            var group = new Class { Name = "Classe 1A", SchoolId = school.Id };
            var group2 = new Class { Name = "Classe 2B", SchoolId = school2.Id };

            var course = new Course { Type = CourseType.Informatique};
            var course2 = new Course { Type = CourseType.Français};

            var sequence = new Sequence
            {
                Title = "Séquence 1 : Les bases de l'informatique",
                Description = "Cette séquence couvre les concepts fondamentaux de l'informatique."
            };

            var sequence2 = new Sequence
            {
                Title = "Séquence 1 : La conjugaison",
                Description = "Cette séquence couvre les concepts fondamentaux de la conjugaison."
            };

            var lesson = new Lesson { Title = "Introduction aux algorithmes" };
            var lesson2 = new Lesson { Title = "Les verbes irréguliers" };

            var resource = new Resource { Title = "Vidéo intro", Url = "https://example.com", Type = Resource.ResourceType.Video };
            var resource2 = new Resource { Title = "Article MDN", Url = "https://mdn.com", Type = Resource.ResourceType.Article };

            var courseInfo = new ClassCourse { ClassId = group.Id, CourseId = course.Id, Type = course.Type };
            var courseInfo2 = new ClassCourse { ClassId = group2.Id, CourseId = course2.Id, Type = course2.Type };

            var courseSequence = new CourseSequence
            {
                CourseId = courseInfo.Id,
                SequenceId = sequence.Id,
                LessonsIds = new List<Guid> { lesson.Id }
            };

            var courseSequence2 = new CourseSequence
            {
                CourseId = courseInfo2.Id,
                SequenceId = sequence2.Id,
                LessonsIds = new List<Guid> { lesson2.Id }
            };

            var courseLesson = new CourseLesson
            {
                CourseId = courseInfo.Id,
                CourseSequenceId = courseSequence.Id,
                LessonId = lesson.Id
            };

            var courseLesson2 = new CourseLesson
            {
                CourseId = courseInfo2.Id,
                CourseSequenceId = courseSequence2.Id,
                LessonId = lesson2.Id
            };

            var today = DateOnly.FromDateTime(DateTime.Today);

            var entries = new List<CalendarEntry>
            {
                new CalendarEntry(courseInfo, today, new TimeOnly(8, 0),  CalendarEntryType.Lesson, courseLesson, lesson),
                new CalendarEntry(courseInfo, today, new TimeOnly(10, 0), CalendarEntryType.Lesson, courseLesson, lesson),
                new CalendarEntry(courseInfo, today.AddDays(3), new TimeOnly(9, 0),  CalendarEntryType.NeedsSequence),
                new CalendarEntry(courseInfo, today.AddDays(4), new TimeOnly(11, 0), CalendarEntryType.Lesson, courseLesson, lesson),
            };

            var entries2 = new List<CalendarEntry>
            {
                new CalendarEntry(courseInfo2, today, new TimeOnly(11, 0),  CalendarEntryType.Lesson, courseLesson2, lesson2),
                new CalendarEntry(courseInfo2, today, new TimeOnly(14, 0), CalendarEntryType.Lesson, courseLesson2, lesson2),
                new CalendarEntry(courseInfo2, today.AddDays(3), new TimeOnly(13, 0),  CalendarEntryType.NeedsSequence),
                new CalendarEntry(courseInfo2, today.AddDays(7), new TimeOnly(11, 0), CalendarEntryType.Lesson, courseLesson2, lesson2),
            };

            var entriesCombined = entries.Concat(entries2);

            void PopulateDays(ObservableCollection<CalendarDayViewModel> collection, IEnumerable<CalendarEntry> entries)
            {
                var grouped = entries
                    .OrderBy(e => e.Date).ThenBy(e => e.Time)
                    .GroupBy(e => e.Date)
                    .Select(g => new CalendarDayViewModel(
                        g.Key,
                        g.Select(e => new CalendarEntryViewModel(e))
                    ));

                foreach (var day in grouped)
                    collection.Add(day);
            }

            PopulateDays(ThisWeekDays, entriesCombined.Where(e => e.Date < today.AddDays(7)));
            PopulateDays(NextWeekDays, entriesCombined.Where(e => e.Date >= today.AddDays(7)));
        }
    }
}