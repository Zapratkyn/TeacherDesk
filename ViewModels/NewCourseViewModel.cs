using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using TeacherDesk.Services;
using TeacherDesk.Models;

namespace TeacherDesk.ViewModels
{
    public partial class NewCourseViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;
        private readonly IStorageService _storage;
        private readonly ObservableCollection<Course> _courses;

        public Array CourseTypes { get; } = Enum.GetValues(typeof(CourseType));

        [ObservableProperty]
        private CourseType _newCourseType;

        public NewCourseViewModel(IStorageService storage, Action<ViewModelBase> navigate, ObservableCollection<Course> courses)
        {
            _storage = storage;
            _navigate = navigate;
            _courses = courses;
        }

        [RelayCommand]
        private void CreateCourse()
        {
            var course = new Course
            {
                Type = NewCourseType
            };

            _storage.Save(course);
            _courses.Add(course);

            NewCourseType = CourseType.Français;

            _navigate(new HomeViewModel(_storage, _navigate));
        }
    }
}