namespace BetApp.Maui.Extensions;

public static class ResourcesExtensions
{
    public static T GetValue<T>(this ResourceDictionary dictionary, string key)
    {
        object value;

        dictionary.TryGetValue(key, out value);

        return (T)value;
    }
}
