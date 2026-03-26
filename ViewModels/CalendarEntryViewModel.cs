using CommunityToolkit.Mvvm.ComponentModel;
using TeacherDesk.Models;

namespace TeacherDesk.ViewModels
{
    public partial class CalendarEntryViewModel : ViewModelBase
    {
        public CalendarEntry Entry { get; }

        [ObservableProperty] private bool _isPrepared;
        [ObservableProperty] private bool _isSchoolExpanded;
        [ObservableProperty] private bool _isLessonExpanded;
        [ObservableProperty] private bool _isResourcesExpanded;

        public string CourseType => Entry.Course.Type?.ToString() ?? "—";
        public string LessonTitle => Entry.Lesson?.Title ?? "—";
        public string SchoolName => Entry.Course.Class?.School?.Name ?? "—";
        public string SchoolAddress => Entry.Course.Class?.School?.Address ?? "—";
        public List<Resource> Resources => Entry.Course.Resources;

        public bool IsLesson => Entry.Type == CalendarEntryType.Lesson;
        public bool IsAlert => Entry.Type == CalendarEntryType.NeedsSequence;

        public CalendarEntryViewModel(CalendarEntry entry)
        {
            Entry = entry;
            _isPrepared = entry.CourseLesson?.IsPrepared ?? false;
        }
    }
}