using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private IStorageService _storage = new JsonStorageService("./data");

        [ObservableProperty]
        private ViewModelBase _currentViewModel;

        public MainWindowViewModel()
        {
            CurrentViewModel = new HomeViewModel(_storage, vm => CurrentViewModel = vm);
        }

        [RelayCommand]
        private void NavigateToHome()
        {
            if (CurrentViewModel is not HomeViewModel)
                CurrentViewModel = new HomeViewModel(_storage, vm => CurrentViewModel = vm);
        }

        [RelayCommand]
        private void NavigateToCalendar()
        {
            if (CurrentViewModel is not CalendarTestViewModel)
                CurrentViewModel = new CalendarTestViewModel(_storage);
        }

        [RelayCommand]
        private void NavigateToCoursesCommand()
        {
            // if (CurrentViewModel is not CoursesViewModel)
            //     CurrentViewModel = new CoursesViewModel(_storage);
        }

        [RelayCommand]
        private void NavigateToSchoolsCommand()
        {
            // if (CurrentViewModel is not SchoolsViewModel)
            //     CurrentViewModel = new SchoolsViewModel(_storage);
        }
    }
}
