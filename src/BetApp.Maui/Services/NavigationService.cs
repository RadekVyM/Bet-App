using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;

namespace BetApp.Maui.Services;

public class NavigationService : INavigationService
{
    private const string ParametersKey = "Parameters";

    private readonly IList<PageType> rootPages = new List<PageType> {
        PageType.MatchesPage,
        PageType.CalendarPage,
        PageType.FavoritesPage,
        PageType.CupPage,
    };


    public NavigationService()
    {
    }


    public void GoBack()
    {
        Shell.Current.GoToAsync("..");
    }

    public async void GoTo(PageType pageType, IParameters parameters = null)
    {
        await Shell.Current.GoToAsync(GetPageRoute(pageType), true, new Dictionary<string, object>
        {
            [ParametersKey] = parameters
        });
    }

    private string GetPageRoute(PageType pageType)
    {
        if (rootPages.Contains(pageType))
            return $"///{pageType.ToString()}";
        return pageType.ToString();
    }
}