using Maui.BindableProperty.Generator.Core;

namespace BetApp.Maui.Views.Controls;

public partial class TabItem : ContentView
{
    [AutoBindable]
    readonly bool isSelected;
    [AutoBindable]
    readonly string text;


    public TabItem()
	{
		InitializeComponent();
	}
}
