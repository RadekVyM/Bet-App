using System;
using BetApp.Avalonia.Views;
using System.Collections.Generic;
using BetApp.Core;
using Avalonia.Controls;
using Avalonia.Layout;
using Microsoft.Extensions.DependencyInjection;

namespace BetApp.Avalonia.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider serviceProvider;

    private readonly Dictionary<PagesEnum, RootPageContent> rootPages = new Dictionary<PagesEnum, RootPageContent>
    {
        [PagesEnum.MatchesPage] = new RootPageContent(PagesEnum.MatchesPage),
        [PagesEnum.CalendarPage] = new RootPageContent(PagesEnum.CalendarPage),
        [PagesEnum.FavoritesPage] = new RootPageContent(PagesEnum.FavoritesPage),
        [PagesEnum.CupPage] = new RootPageContent(PagesEnum.CupPage),
    };

    private readonly Dictionary<PagesEnum, Type> pageTypes = new Dictionary<PagesEnum, Type>
    {
        [PagesEnum.MatchesPage] = typeof(MatchesPage),
        [PagesEnum.CalendarPage] = typeof(CalendarPage),
        [PagesEnum.FavoritesPage] = typeof(FavoritesPage),
        [PagesEnum.CupPage] = typeof(CupPage),
        [PagesEnum.MatchDetailPage] = typeof(MatchPage),
    };

    private PagesEnum currentRootPage = PagesEnum.MatchesPage;

    public event EventHandler<UserControl>? OnSwitchPage;


    public NavigationService(IServiceProvider serviceProvider)
	{
        this.serviceProvider = serviceProvider;
    }


    public void Pop()
    {
        if (rootPages[currentRootPage].NavigationStack.Count != 0)
            rootPages[currentRootPage].NavigationStack.Pop();

        var content = rootPages[currentRootPage].NavigationStack.Count == 0 ?
            GetPage(rootPages[currentRootPage]) :
            GetPage(rootPages[currentRootPage].NavigationStack.Peek());

        if (content is not null)
            SwitchPage(content);
    }

    public void Push(PagesEnum page, params object[] parameters)
    {
        UserControl? content;

        if (rootPages.ContainsKey(page))
        {
            currentRootPage = page;
            rootPages[currentRootPage].NavigationStack.Clear();

            content = GetPage(rootPages[currentRootPage]);
        }
        else
        {
            var pageContent = new PageContent(page);
            rootPages[currentRootPage].NavigationStack.Push(pageContent);

            content = GetPage(pageContent);
        }

        if (content is not null)
        {
            (content.DataContext as IBasePageViewModel)?.OnPagePushing(parameters);
            SwitchPage(content);
        }
    }

    private void SwitchPage(UserControl page)
    {
        OnSwitchPage?.Invoke(this, page);
    }

    private UserControl? GetPage(PageContent page)
    {
        if (page.Content is not null)
            return page.Content;

        return page.Content = serviceProvider.GetRequiredService(pageTypes[page.Page]) as UserControl;
    }


    private class RootPageContent : PageContent
    {
        public RootPageContent(PagesEnum page) : base(page)
        {
        }

        public Stack<PageContent> NavigationStack { get; } = new Stack<PageContent>();
    }

    private class PageContent
    {
        public PagesEnum Page { get; }
        public UserControl? Content { get; set; }

        public PageContent(PagesEnum page)
        {
            Page = page;
        }
    }
}
