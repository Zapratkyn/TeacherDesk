using System.Collections.ObjectModel;
using TeacherDesk.Models;

namespace TeacherDesk.ViewModels
{
    public partial class CalendarTestViewModel : ViewModelBase
    {
        public ObservableCollection<Course>? Courses { get; } = new();

        public CalendarTestViewModel()
        {
            var course1 = new Course 
            { 
                Type = CourseType.Anglais,
                Schedule = new List<CourseSlot>
                {
                    new CourseSlot(DayOfWeek.Monday, new TimeOnly(9, 0)),
                    new CourseSlot(DayOfWeek.Wednesday, new TimeOnly(10, 0))
                }
            };
            Courses.Add(course1);
        }
    }
}