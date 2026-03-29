using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;

        [ObservableProperty]
        private ViewModelBase _currentViewModel;

        [ObservableProperty]
        private bool _isFirstTime = ServiceLocator.Instance.CacheSize == 0;

        public MainWindowViewModel()
        {
            _navigate = vm => CurrentViewModel = vm;
            CurrentViewModel = IsFirstTime ? 
                new WelcomeViewModel(_navigate, value => IsFirstTime = value) : 
                new HomeViewModel(_navigate);
        }

        [RelayCommand]
        private void NavigateToHome()
        {
            if (CurrentViewModel is not HomeViewModel)
                CurrentViewModel = new HomeViewModel(_navigate);
        }

        [RelayCommand]
        private void NavigateToCalendar()
        {
            if (CurrentViewModel is not CalendarTestViewModel)
                CurrentViewModel = new CalendarTestViewModel();
        }

        [RelayCommand]
        private void NavigateToCourses()
        {
            Console.WriteLine("Navigate to Courses");
            // if (CurrentViewModel is not CoursesViewModel)
            //     CurrentViewModel = new CoursesViewModel(_storage);
        }

        [RelayCommand]
        private void NavigateToSchools()
        {
            // if (CurrentViewModel is not SchoolsViewModel)
            //     CurrentViewModel = new SchoolsViewModel(_storage);
        }
    }
}
