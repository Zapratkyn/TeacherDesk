using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using TeacherDesk.Services;
using TeacherDesk.Models;

namespace TeacherDesk.ViewModels
{
    public partial class NewSchoolViewModel : ViewModelBase
    {
        private readonly Action<ViewModelBase> _navigate;
        private readonly IStorageService _storage;
        private readonly ObservableCollection<School> _schools;

        [ObservableProperty]
        private bool _displayError = false;
        [ObservableProperty]
        private string _newSchoolError = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateSchoolCommand))]
        private string _newSchoolName = string.Empty;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateSchoolCommand))]
        private string _newSchoolAddress = string.Empty;

        public NewSchoolViewModel(IStorageService storage, Action<ViewModelBase> navigate, ObservableCollection<School> schools)
        {
            _storage = storage;
            _navigate = navigate;
            _schools = schools;
        }

        [RelayCommand(CanExecute = nameof(CanCreateSchool))]
        private void CreateSchool()
        {
            var school = new School
            {
                Name = NewSchoolName,
                Address = NormalizeAddress(NewSchoolAddress)
            };

            bool alreadyExists = _schools.Any(s =>
                s.Name.Equals(school.Name, StringComparison.OrdinalIgnoreCase) ||
                s.Address.Equals(school.Address, StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
            {
                NewSchoolError = "Cette école existe déjà.";
                DisplayError = true;
                return;
            }

            _storage.Save(school);
            _schools.Add(school);

            NewSchoolName = string.Empty;
            NewSchoolAddress = string.Empty;

            _navigate(new HomeViewModel(_storage, _navigate));
        }

        private string NormalizeAddress(string address)
        {
            return address
                .ToLowerInvariant()
                .Trim()
                .Replace("  ", " ")        // doubles espaces
                .Replace("street", "st")
                .Replace("avenue", "av")
                .Replace("boulevard", "bd");
        }

        private bool CanCreateSchool() =>
            !string.IsNullOrWhiteSpace(NewSchoolName) &&
            !string.IsNullOrWhiteSpace(NewSchoolAddress);

        [RelayCommand]
        private void Cancel()
        {
            _navigate(new HomeViewModel(_storage, _navigate));
        }
    }
}