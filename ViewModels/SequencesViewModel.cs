using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TeacherDesk.Models;
using TeacherDesk.Services;

namespace TeacherDesk.ViewModels
{
    public partial class SequencesViewModel : ViewModelBase
    {
        private IStorageService _storage;

        public ObservableCollection<Sequence> Sequences { get; set; } = [];

        // [ObservableProperty]
        // private Sequence? _selectedSequence;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateSequenceCommand))]
        private string _newSequenceTitle = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateSequenceCommand))]
        private string _newSequenceDescription = string.Empty;

        public SequencesViewModel(IStorageService storage)
        {
            _storage = storage;
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

        [RelayCommand(CanExecute = nameof(CanCreateSequence))]
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

        private bool CanCreateSequence()
        {
            return !string.IsNullOrWhiteSpace(NewSequenceTitle) &&
                   !string.IsNullOrWhiteSpace(NewSequenceDescription);
        }

        [RelayCommand]
        private void DeleteSequence(Sequence sequence)
        {
            _storage.Delete(sequence.Id);
            Sequences.Remove(sequence);
        }
    }
}