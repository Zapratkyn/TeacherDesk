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
        private readonly ObservableCollection<ClassCourse> _courses;

        public Array CourseTypes { get; } = Enum.GetValues(typeof(CourseType));

        [ObservableProperty]
        private CourseType? _newCourseType = null;

        public NewCourseViewModel(IStorageService storage, Action<ViewModelBase> navigate, ObservableCollection<ClassCourse> courses)
        {
            _storage = storage;
            _navigate = navigate;
            _courses = courses;
        }

        [RelayCommand]
        private void CreateCourse()
        {
            var school = new School { Name = "Athénée Royal", Address = "Rue de la Loi 1, Bruxelles" };

            var group = new Class { SchoolId = school.Id, Name = "Classe 1A" };

            var course = new Course { Type = CourseType.Informatique};
            
            var courseInfo = new ClassCourse
            {
                Type = course.Type,
                ClassId = group.Id,
                CourseId = course.Id,
                SchoolId = school.Id
            };

            _storage.Save(courseInfo);
            _courses.Add(courseInfo);

            NewCourseType = null;

            _navigate(new HomeViewModel(_storage, _navigate));
        }

        [RelayCommand]
        private void Cancel()
        {
            _navigate(new HomeViewModel(_storage, _navigate));
        }
    }
}