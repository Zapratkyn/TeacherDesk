using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TeacherDesk.Models;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private IStorageService _storage = new JsonStorageService("./data");

        [ObservableProperty]
        private ViewModelBase? _currentViewModel;

        [RelayCommand]
        private void ShowSequences()
        {
            CurrentViewModel = new SequencesViewModel(_storage);
        }

        [RelayCommand]
        private void ShowHome()
        {
            CurrentViewModel = null;
        }
    }
}
