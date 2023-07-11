using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Avalonia.Controls;
using BetApp.Core;
using Microsoft.Extensions.DependencyInjection;
using Avalonia.Layout;
using BetApp.Avalonia.Services;

namespace BetApp.Avalonia.Views;

public partial class ShellView : UserControl
{
    private readonly NavigationService? navigationService;


    public ShellView()
    {
        InitializeComponent();
    }

    public ShellView(NavigationService navigationService) : this()
    {
        this.navigationService = navigationService;

        navigationService.OnSwitchPage += SwitchPage;
        navigationService.Push(PagesEnum.MatchesPage);
    }


    private void BackClick(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        navigationService?.Pop();
    }

    private void MatchesClick(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        navigationService?.Push(PagesEnum.MatchesPage);
    }

    private void CalendarClick(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        navigationService?.Push(PagesEnum.CalendarPage);
    }

    private void FavoritesClick(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        navigationService?.Push(PagesEnum.FavoritesPage);
    }

    private void CupClick(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        navigationService?.Push(PagesEnum.CupPage);
    }

    private void SwitchPage(object? sender, UserControl page)
    {
        page.HorizontalAlignment = HorizontalAlignment.Stretch;
        page.VerticalAlignment = VerticalAlignment.Stretch;
        page.HorizontalContentAlignment  = HorizontalAlignment.Stretch;
        page.VerticalContentAlignment = VerticalAlignment.Stretch;

        pageContainer.Children.Clear();
        pageContainer.Children.Add(page);
    }
}