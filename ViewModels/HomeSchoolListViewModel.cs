using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TeacherDesk.Models;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class HomeSchoolListViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;
        private IStorageService Storage => ServiceLocator.Instance.Storage;
        public ObservableCollection<School> Schools { get; } = new();
        public bool HasNoSchools => Schools.Count == 0;

        public HomeSchoolListViewModel(Action<ViewModelBase> navigate)
        {
            _navigate = navigate;
            Schools.CollectionChanged += (_, _) => OnPropertyChanged(nameof(HasNoSchools));
            LoadSchools();
        }

        private void LoadSchools()
        {
            var schools = Storage.LoadAll<School>();
            foreach(var school in schools)
            {
                Schools.Add(school);
            }
        }

        [RelayCommand]
        private void DeleteSchool(School school)
        {
            Schools.Remove(school);
            Storage.Delete<School>(school.Id);
        }

        [RelayCommand]
        private void DisplayNewSchoolForm()
        {
            _navigate(new NewSchoolViewModel(_navigate, Schools));
        }
    }
}