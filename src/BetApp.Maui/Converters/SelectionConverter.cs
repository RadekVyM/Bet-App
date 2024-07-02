using System.Globalization;

namespace BetApp.Maui.Converters;

public class SelectionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var view = parameter as View;

        return view is not null && view.BindingContext == value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}