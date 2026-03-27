using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using TeacherDesk.Models;
using TeacherDesk.Services;
using Avalonia.Media;

namespace TeacherDesk.ViewModels
{
    public partial class CalendarEntryViewModel : ViewModelBase
    {
        private readonly IStorageService _storage;
        public CalendarEntry Entry { get; }
        public ObservableCollection<Resource>? Resources { get; set; }

        [ObservableProperty] private bool _isPrepared;
        [ObservableProperty] private bool _isSchoolExpanded;
        [ObservableProperty] private bool _isLessonExpanded;
        [ObservableProperty] private bool _isResourcesExpanded;
        [ObservableProperty] private string? _lessonTitle;
        [ObservableProperty] private string? _schoolName;
        [ObservableProperty] private string? _schoolAddress;

        public string ClassName => Entry.Course.Class?.Name ?? "";
        public string CourseType => Entry.Course.Type.ToString() ?? "—";

        public bool IsLesson => Entry.Type == CalendarEntryType.Lesson;
        public bool IsAlert => Entry.Type == CalendarEntryType.NeedsSequence;

        public IBrush EntryBackground => IsPrepared 
            ? new SolidColorBrush(Color.FromArgb(255, 144, 238, 144)) // Vert clair
            : new SolidColorBrush(Color.FromArgb(255, 245, 245, 245)); // Gris clair

        partial void OnIsPreparedChanged(bool value)
        {
            OnPropertyChanged(nameof(EntryBackground));
        }

        [RelayCommand]
        private void ExpandSchool()
        {
            if (SchoolName == "—" && !IsSchoolExpanded)
            {
                var s = _storage.Load<School>(Entry.Course.SchoolId);
                SchoolName = s?.Name ?? "—";
                SchoolAddress = s?.Address ?? "—";
            }
            IsSchoolExpanded = !IsSchoolExpanded;
        }

        [RelayCommand]
        private void ExpandLesson()
        {
            if (LessonTitle == null && !IsLessonExpanded && Entry.CourseLesson != null)
            {
                var l = _storage.Load<Lesson>(Entry.CourseLesson.Id);
                LessonTitle = l?.Title ?? "—";
            }
            IsLessonExpanded = !IsLessonExpanded;
        }

        [RelayCommand]
        private void ExpandResources()
        {
            if (Resources == null && !IsResourcesExpanded && Entry.CourseLesson?.ResourcesIds != null)
            {
                var resources = _storage.LoadMany<Resource>(Entry.CourseLesson.ResourcesIds);
                Resources = new ObservableCollection<Resource>(resources);
            }
            IsResourcesExpanded = !IsResourcesExpanded;
        }

        public CalendarEntryViewModel(IStorageService storage, CalendarEntry entry)
        {
            Entry = entry;
            _storage = storage;
            IsPrepared = entry.CourseLesson?.IsPrepared ?? false;
        }
    }
}