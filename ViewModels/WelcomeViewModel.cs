using CommunityToolkit.Mvvm.Input;

namespace TeacherDesk.ViewModels
{
    public partial class WelcomeViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;
        private readonly Action<bool> _setIsFirstTime;

        public WelcomeViewModel(Action<ViewModelBase> navigate, Action<bool> setIsFirstTime)
        {
            _navigate = navigate;
            _setIsFirstTime = setIsFirstTime;
        }

        [RelayCommand]
        private void TestFirstTime()
        {
            _setIsFirstTime(false);
            _navigate(new HomeViewModel(_navigate));
        }
    }
}