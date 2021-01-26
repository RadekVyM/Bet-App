using BetApp.Core;
using System.Linq;
using Xamarin.Forms;

namespace BetApp
{
    public class NavigationService : INavigationService
    {
        public void Pop()
        {
            Shell.Current.Navigation.PopAsync();
        }

        public void Push(PagesEnum page, params object[] parameters)
        {
            Shell.Current.GoToAsync(page.ToString());
            Page lastPage = Shell.Current.Navigation.NavigationStack.LastOrDefault();

            if (lastPage != null)
                ((IBasePageViewModel)lastPage.BindingContext).OnPagePushing(parameters);
        }
    }
}
