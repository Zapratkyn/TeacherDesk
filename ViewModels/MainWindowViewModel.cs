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
            // CurrentViewModel = new HomeViewModel(_storage, vm => CurrentViewModel = vm);
            CurrentViewModel = new CalendarTestViewModel(_storage);
        }
    }
}
