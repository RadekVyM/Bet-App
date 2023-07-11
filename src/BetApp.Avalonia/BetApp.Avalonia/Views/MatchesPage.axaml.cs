using Avalonia.Controls;
using BetApp.Core;

namespace BetApp.Avalonia.Views;

public partial class MatchesPage : UserControl
{
    public MatchesPage()
    {
        InitializeComponent();
    }

    public MatchesPage(IMatchesPageViewModel matchesPageViewModel) : this()
    {
        DataContext = matchesPageViewModel;
    }
}