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

        public ObservableCollection<Sequence> Sequences { get; set; } = [];

        // [ObservableProperty]
        // private Sequence? _selectedSequence;

        [ObservableProperty]
        private string _newSequenceTitle = string.Empty;

        [ObservableProperty]
        private string _newSequenceDescription = string.Empty;

        public MainWindowViewModel()
        {
            LoadSequences();
        }

        private void LoadSequences()
        {
            var sequences = _storage.LoadAll();
            foreach(var sequence in sequences)
            {
                Sequences.Add(sequence);
            }
        }

        [RelayCommand]
        private void CreateSequence()
        {
            if (string.IsNullOrWhiteSpace(NewSequenceTitle))
                return;

            var sequence = new Sequence
            {
                Title = NewSequenceTitle,
                Description = NewSequenceDescription
            };

            _storage.Save(sequence);
            Sequences.Add(sequence);

            NewSequenceTitle = string.Empty;
            NewSequenceDescription = string.Empty;
        }


    }
}
