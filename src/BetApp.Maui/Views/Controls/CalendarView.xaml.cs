using System.Windows.Input;
using BetApp.Core.ViewModels;
using Maui.BindableProperty.Generator.Core;

namespace BetApp.Maui.Views.Controls;

public partial class CalendarView : ContentView
{
    [AutoBindable]
    readonly ICommand selectedDateChangedCommand;
    [AutoBindable]
    readonly object selectedDateChangedCommandParameter;
    [AutoBindable(DefaultBindingMode = "TwoWay", DefaultValue = "DateTime.Now")]
    readonly DateTime selectedDate;

    List<DayItem> calendarDays;
    DateTime currentMonthDateTime;
    DayItem selectedDay;

    public DayItem SelectedDay
    {
        get => selectedDay;
        set
        {
            if (selectedDay is not null)
                selectedDay.IsSelected = false;
            selectedDay = value;
            selectedDay.IsSelected = true;
            OnPropertyChanged(nameof(SelectedDay));
        }
    }
    public DateTime CurrentMonthDateTime
    {
        get => currentMonthDateTime;
        set
        {
            currentMonthDateTime = value;
            OnPropertyChanged(nameof(CurrentMonthDateTime));
        }
    }
    

    public CalendarView()
    {
        calendarDays = [];

        InitializeComponent();

        UpdateCalendar(DateTime.Today);
        
        SelectedDay = calendarDays.FirstOrDefault(d => DateTime.Today == d.Date.Date);
    }


    private void UpdateCalendar(DateTime month)
    {
        CurrentMonthDateTime = month;
        calendarDays = [];

        var firstDay = new DateTime(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month, 1);
        var lastDay = new DateTime(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month, DateTime.DaysInMonth(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month));
        var previousMonth = CurrentMonthDateTime.AddMonths(-1);
        var nextMonth = CurrentMonthDateTime.AddMonths(1);

        var daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
        var skipDays = daysInPreviousMonth - ((firstDay.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)firstDay.DayOfWeek) - 1);
        calendarDays = calendarDays
            .Concat(Enumerable.Range(1, daysInPreviousMonth)
            .Skip(skipDays)
            .Select(d => new DayItem { Date = new DateTime(previousMonth.Year, previousMonth.Month, d), IsSelectedMonth = false }))
            .ToList();
        var daysInCurrentMonth = DateTime.DaysInMonth(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month);
        calendarDays = calendarDays
            .Concat(Enumerable.Range(1, daysInCurrentMonth)
            .Select(d => new DayItem { Date = new DateTime(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month, d), IsSelectedMonth = true }))
            .ToList();
        var daysInNextMonth = DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month);
        var takeDays = 7 - (lastDay.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)lastDay.DayOfWeek);
        calendarDays = calendarDays
            .Concat(Enumerable.Range(1, daysInNextMonth)
            .Take(takeDays)
            .Select(d => new DayItem { Date = new DateTime(nextMonth.Year, nextMonth.Month, d), IsSelectedMonth = false }))
            .ToList();

        if (SelectedDay is not null && SelectedDay.Date.Year == CurrentMonthDateTime.Year && SelectedDay.Date.Month == CurrentMonthDateTime.Month)
        {
            var day = calendarDays.FirstOrDefault(d => SelectedDay.Date == d.Date.Date);

            if (day is not null)
            {
                SelectedDay = day;
                SelectedDate = SelectedDay.Date;
            }
        }
        
        collectionView.ItemsSource = calendarDays;
    }

    private void DayItemTapped(object sender, EventArgs e)
    {
        var day = (sender as BindableObject).BindingContext as DayItem;

        if(!day.IsSelectedMonth)
            UpdateCalendar(day.Date);

        SelectedDay = calendarDays.FirstOrDefault(d => day.Date == d.Date.Date);
        SelectedDate = SelectedDay.Date;

        if(SelectedDateChangedCommand is not null)
        {
            if (SelectedDateChangedCommand.CanExecute(SelectedDateChangedCommandParameter))
                SelectedDateChangedCommand.Execute(SelectedDateChangedCommandParameter);
        }
    }

    private void LeftTapped(object sender, EventArgs e)
    {
        UpdateCalendar(CurrentMonthDateTime.AddMonths(-1));
    }

    private void RightTapped(object sender, EventArgs e)
    {
        UpdateCalendar(CurrentMonthDateTime.AddMonths(1));
    }

    public class DayItem : BaseViewModel
    {
        private bool isSelected;

        public DateTime Date { get; set; }
        public string Day => Date.Day.ToString().PadLeft(2, '0');
        public bool IsSelectedMonth { get; set; }

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}