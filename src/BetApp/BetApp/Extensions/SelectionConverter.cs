using System;
using System.Globalization;
using Xamarin.Forms;

namespace BetApp
{
    public class SelectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            View view = parameter as View;

            if (!(view == null))
            {
                if (view.BindingContext?.GetHashCode() == value?.GetHashCode())
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
