using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TeacherDesk.Models;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class HomeSchoolListViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;
        private readonly IStorageService _storage;
        public ObservableCollection<School> Schools { get; } = new();
        public bool HasNoSchools => Schools.Count == 0;

        public HomeSchoolListViewModel(IStorageService storage, Action<ViewModelBase> navigate)
        {
            _storage = storage;
            _navigate = navigate;
            Schools.CollectionChanged += (_, _) => OnPropertyChanged(nameof(HasNoSchools));
            LoadSchools();
        }

        private void LoadSchools()
        {
            var schools = _storage.LoadAll<School>();
            foreach(var school in schools)
            {
                Schools.Add(school);
            }
        }

        [RelayCommand]
        private void DeleteSchool(School school)
        {
            Schools.Remove(school);
            _storage.Delete<School>(school.Id);
        }

        [RelayCommand]
        private void DisplayNewSchoolForm()
        {
            _navigate(new NewSchoolViewModel(_storage, _navigate, Schools));
        }
    }
}