using SimpleToolkit.Core;
using Maui.BindableProperty.Generator.Core;

namespace BetApp.Maui.Views.Controls;

public partial class TwoLinesButton : ContentButton
{
    [AutoBindable]
    readonly string firstLine;
    [AutoBindable]
    readonly string secondLine;
    [AutoBindable]
    readonly Color textColor;

    public TwoLinesButton()
    {
        InitializeComponent();
    }
}