using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TeacherDesk.Models;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;
        private readonly IStorageService _storage;
        public ObservableCollection<Course> Courses { get; } = new();
        public bool HasNoCourses => Courses.Count == 0;

        public HomeViewModel(IStorageService storage, Action<ViewModelBase> navigate)
        {
            _storage = storage;
            _navigate = navigate;
            Courses.CollectionChanged += (_, _) => OnPropertyChanged(nameof(HasNoCourses));
            LoadCourses();
        }

        private void LoadCourses()
        {
            var courses = _storage.LoadAll<Course>();
            foreach(var course in courses)
            {
                Courses.Add(course);
            }
        }

        [RelayCommand]
        private void DeleteCourse(Course course)
        {
            Courses.Remove(course);
            _storage.Delete<Course>(course.Id);
        }

        [RelayCommand]
        private void DisplayNewCourseForm()
        {
            _navigate(new NewCourseViewModel(_storage, _navigate, Courses));
        }
    }
}