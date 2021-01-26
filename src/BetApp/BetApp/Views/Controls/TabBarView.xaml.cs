using BetApp.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabBarView : ContentView
    {
        private bool isTabBarShown = true;

        public TabBarView()
        {
            InitializeComponent();

            _ = ChangeIconsSelection(matchesGrid);
        }

        private void MatchesTapped(object sender, EventArgs e)
        {
            _ = ChangeIconsSelection(sender as Grid);
            Shell.Current.GoToAsync("///" + PagesEnum.MatchesPage.ToString());
        }

        private void CalendarTapped(object sender, EventArgs e)
        {
            _ = ChangeIconsSelection(sender as Grid);
            Shell.Current.GoToAsync("///" + PagesEnum.CalendarPage.ToString());
        }

        private void StarTapped(object sender, EventArgs e)
        {
            _ = ChangeIconsSelection(sender as Grid);
            Shell.Current.GoToAsync("///" + PagesEnum.FavoritesPage.ToString());
        }

        private void CupTapped(object sender, EventArgs e)
        {
            _ = ChangeIconsSelection(sender as Grid);
            Shell.Current.GoToAsync("///" + PagesEnum.CupPage.ToString());
        }

        private async Task ChangeIconsSelection(Grid selectedGrid)
        {
            List<Task> tasks = new List<Task>();
            List<View> unselectedViews = new List<View>(mainGrid.Children);

            unselectedViews.Remove(selectedGrid);

            foreach (var view in unselectedViews)
                tasks.Add(ChangeIconSelection((view as Grid), false));

            tasks.Add(ChangeIconSelection(selectedGrid, true));

            await Task.WhenAll(tasks);
        }

        public async Task ShowTabBarAsync()
        {
            if (!isTabBarShown)
                await mainGrid.TranslateTo(0, 0);
            isTabBarShown = true;
        }

        public async Task HideTabBarAsync()
        {
            if (isTabBarShown)
                await mainGrid.TranslateTo(0, Height);
            isTabBarShown = false;
        }

        private async Task ChangeIconSelection(Grid grid, bool selected)
        {
            await grid?.Children[1].TranslateTo(grid.TranslationX, selected ? 0 : Height);
            grid.Children[1].TranslationY = selected ? 0 : Height;
        }
    }
}