using System.Collections.ObjectModel;
using TeacherDesk.Models;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {
        private IStorageService _storage;
        public ObservableCollection<Course> Courses { get; } = new();
        public bool HasNoCourses => Courses.Count == 0;

        public HomeViewModel(IStorageService storage)
        {
            _storage = storage;
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
    }
}