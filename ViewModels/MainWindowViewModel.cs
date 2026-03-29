using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase _currentViewModel;

        public MainWindowViewModel()
        {
            CurrentViewModel = new HomeViewModel(vm => CurrentViewModel = vm);
        }

        [RelayCommand]
        private void NavigateToHome()
        {
            if (CurrentViewModel is not HomeViewModel)
                CurrentViewModel = new HomeViewModel(vm => CurrentViewModel = vm);
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
