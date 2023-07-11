using Avalonia.Controls;

namespace BetApp.Avalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public MainWindow(ShellView shellView) : this()
    {
        Content = shellView;
    }
}