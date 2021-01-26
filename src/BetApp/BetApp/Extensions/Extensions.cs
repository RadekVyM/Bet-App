using BetApp.Core;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BetApp
{
    public static class Extensions
    {
        public static PagesEnum GetCurrentPage(this Shell shell)
        {
            string str = shell.CurrentState.Location.OriginalString.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

            return (PagesEnum)Enum.Parse(typeof(PagesEnum), str);
        }

        public static T GetValue<T>(this ResourceDictionary dictionary, string key)
        {
            object value;

            dictionary.TryGetValue(key, out value);

            return (T)value;
        }

        public static Color GetColour(this object value)
        {
            if (value == null)
                return Color.Transparent;
            if (value.ToString() == "")
                return Color.Transparent;
            if (value is Color color)
                return color;
            else if (value is DynamicResource resource)
                return App.Current.Resources.GetValue<Color>(resource.Key);
            else if (value is string code)
                return Color.FromHex(code);
            else
                return Color.Transparent;
        }
    }
}
