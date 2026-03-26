using System.Collections.ObjectModel;

namespace TeacherDesk.ViewModels
{
    public class CalendarDayViewModel
    {
        public DateOnly Date { get; }
        public string Label { get; }
        public ObservableCollection<CalendarEntryViewModel> Entries { get; }

        public CalendarDayViewModel(DateOnly date, IEnumerable<CalendarEntryViewModel> entries)
        {
            Date = date;
            Label = date.ToString("dddd d MMMM", new System.Globalization.CultureInfo("fr-BE"));
            Entries = new ObservableCollection<CalendarEntryViewModel>(entries);
        }
    }
}