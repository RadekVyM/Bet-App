using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace BetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarView : ContentView
    {
        List<DayItem> calendarDays;
        DateTime currentMonthDateTime;
        DayItem selectedDay;

        public DayItem SelectedDay
        {
            get => selectedDay;
            set
            {
                selectedDay = value;
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
        public ICommand SelectedDateChangedCommand
        {
            get => (ICommand)GetValue(SelectedDateChangedCommandProperty);
            set => SetValue(SelectedDateChangedCommandProperty, value);
        }
        public object SelectedDateChangedCommandParameter
        {
            get => GetValue(SelectedDateChangedCommandParameterProperty);
            set => SetValue(SelectedDateChangedCommandParameterProperty, value);
        }
        public DateTime SelectedDate
        {
            get => (DateTime)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

        public static readonly BindableProperty SelectedDateChangedCommandProperty =
            BindableProperty.Create(nameof(SelectedDateChangedCommand), typeof(ICommand), typeof(CalendarView), null, BindingMode.OneWay);

        public static readonly BindableProperty SelectedDateChangedCommandParameterProperty =
            BindableProperty.Create(nameof(SelectedDateChangedCommandParameter), typeof(object), typeof(CalendarView), null, BindingMode.OneWay);

        public static readonly BindableProperty SelectedDateProperty =
            BindableProperty.Create(nameof(SelectedDate), typeof(DateTime), typeof(CalendarView), DateTime.Now, BindingMode.TwoWay);


        public CalendarView()
        {
            calendarDays = new List<DayItem>();

            InitializeComponent();

            UpdateCalendar(DateTime.Today);
            
            SelectedDay = calendarDays.FirstOrDefault(d => DateTime.Today == d.Date.Date);
        }


        private void UpdateCalendar(DateTime month)
        {
            CurrentMonthDateTime = month;
            calendarDays.Clear();

            DateTime firstDay = new DateTime(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month, 1);
            DateTime lastDay = new DateTime(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month, DateTime.DaysInMonth(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month));
            DateTime previousMonth = CurrentMonthDateTime.AddMonths(-1);
            DateTime nextMonth = CurrentMonthDateTime.AddMonths(1);

            int daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
            int skipDays = daysInPreviousMonth - ((firstDay.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)firstDay.DayOfWeek) - 1);
            calendarDays = calendarDays
                .Concat(Enumerable.Range(1, daysInPreviousMonth)
                .Skip(skipDays)
                .Select(d => new DayItem { Date = new DateTime(previousMonth.Year, previousMonth.Month, d), IsSelectedMonth = false }))
                .ToList();
            int daysInCurrentMonth = DateTime.DaysInMonth(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month);
            calendarDays = calendarDays
                .Concat(Enumerable.Range(1, daysInCurrentMonth)
                .Select(d => new DayItem { Date = new DateTime(CurrentMonthDateTime.Year, CurrentMonthDateTime.Month, d), IsSelectedMonth = true }))
                .ToList();
            int daysInNextMonth = DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month);
            int takeDays = 7 - (lastDay.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)lastDay.DayOfWeek);
            calendarDays = calendarDays
                .Concat(Enumerable.Range(1, daysInNextMonth)
                .Take(takeDays)
                .Select(d => new DayItem { Date = new DateTime(nextMonth.Year, nextMonth.Month, d), IsSelectedMonth = false }))
                .ToList();

            collectionView.ItemsSource = calendarDays;

            if(SelectedDay != null)
            {
                if (SelectedDay.Date.Year == CurrentMonthDateTime.Year && SelectedDay.Date.Month == CurrentMonthDateTime.Month)
                {
                    var day = calendarDays.FirstOrDefault(d => SelectedDay.Date == d.Date.Date);

                    if (day != null)
                    {
                        SelectedDay = day;
                        SelectedDate = SelectedDay.Date;
                    }
                }
            }
        }

        private void DayItemTapped(object sender, EventArgs e)
        {
            var day = ((sender as BindableObject).BindingContext as DayItem);

            if(!day.IsSelectedMonth)
                UpdateCalendar(day.Date);

            SelectedDay = calendarDays.FirstOrDefault(d => day.Date == d.Date.Date);
            SelectedDate = SelectedDay.Date;

            if(SelectedDateChangedCommand != null)
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
    }

    public class DayItem
    {
        public DateTime Date { get; set; }
        public int Day => Date.Day;
        public bool IsSelectedMonth { get; set; }
    }
}