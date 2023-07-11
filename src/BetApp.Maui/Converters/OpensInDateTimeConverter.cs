using System.Globalization;

namespace BetApp.Maui.Converters;

public class OpensInDateTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        DateTime time = (DateTime)value;
        string dateTimeString = "";

        if (time.Date == DateTime.Today)
            dateTimeString += "Today";
        else if (time.Date == DateTime.Today.AddDays(1))
            dateTimeString += "Tomorrow";
        else
            dateTimeString += time.ToString("d. M. yyyy");

        dateTimeString += " " + time.ToString("HH:mm");

        if (time < DateTime.Now)
            return dateTimeString;

        dateTimeString += " (Opens in";

        TimeSpan timeSpan = time - DateTime.Now;

        if (timeSpan.Days > 0)
            dateTimeString += " " + timeSpan.Days + " " + (timeSpan.Days == 1 ? "day" : "days");

        if (timeSpan.Hours > 0)
            dateTimeString += " " + timeSpan.Hours + " " + (timeSpan.Hours == 1 ? "hr" : "hrs");

        if (timeSpan.Minutes > 0)
            dateTimeString += " " + timeSpan.Minutes + " " + (timeSpan.Minutes == 1 ? "min" : "mins");

        dateTimeString += ")";

        return dateTimeString;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}