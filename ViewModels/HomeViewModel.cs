using System.Collections.ObjectModel;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;

        public ObservableCollection<ViewModelBase> Lists { get; }

        public HomeViewModel(Action<ViewModelBase> navigate)
        {
            _navigate = navigate;
            Lists = new()
            {
                new HomeCourseListViewModel(_navigate),
                new HomeSchoolListViewModel(_navigate)
            };
        }
    }
}