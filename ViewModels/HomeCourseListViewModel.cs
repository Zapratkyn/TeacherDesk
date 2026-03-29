using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TeacherDesk.Models;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class HomeCourseListViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;
        private IStorageService Storage => ServiceLocator.Instance.Storage;
        public ObservableCollection<ClassCourse> Courses { get; } = new();
        public bool HasNoCourses => Courses.Count == 0;

        public HomeCourseListViewModel(Action<ViewModelBase> navigate)
        {
            _navigate = navigate;
            Courses.CollectionChanged += (_, _) => OnPropertyChanged(nameof(HasNoCourses));
            LoadCourses();
        }

        private void LoadCourses()
        {
            var courses = Storage.LoadAll<ClassCourse>();
            foreach(var course in courses)
            {
                Courses.Add(course);
            }
        }

        [RelayCommand]
        private void DeleteCourse(ClassCourse course)
        {
            Courses.Remove(course);
            Storage.Delete<ClassCourse>(course.Id);
        }

        [RelayCommand]
        private void DisplayNewCourseForm()
        {
            _navigate(new NewCourseViewModel(_navigate, Courses));
        }
    }
}