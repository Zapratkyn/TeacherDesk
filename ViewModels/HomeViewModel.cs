using System.Collections.ObjectModel;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;
        private readonly IStorageService _storage;

        public ObservableCollection<ViewModelBase> Lists { get; }

        public HomeViewModel(IStorageService storage, Action<ViewModelBase> navigate)
        {
            _storage = storage;
            _navigate = navigate;
            Lists = new()
            {
                new HomeCourseListViewModel(_storage, _navigate),
                new HomeSchoolListViewModel(_storage, _navigate)
            };
        }
    }
}