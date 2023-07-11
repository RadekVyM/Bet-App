using BetApp.Core.Interfaces.ViewModels;

namespace BetApp.Core.Interfaces.Services;

public enum PageType
{
    MatchesPage,
    CalendarPage,
    FavoritesPage,
    CupPage,
    MatchDetailPage
}

public interface INavigationService
{
    void GoTo(PageType pageType, IParameters? parameters = null);
    void GoBack();
}
