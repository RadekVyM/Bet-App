using Maui.BindableProperty.Generator.Core;

namespace BetApp.Maui.Views.Controls;

public partial class TabBarItem : ContentView
{
     [AutoBindable(DefaultValue = "false")]
    readonly bool isSelected;

    public event EventHandler Clicked { add => button.Clicked += value; remove => button.Clicked -= value; }


    public TabBarItem()
	{
		InitializeComponent();
	}


    partial void OnIsSelectedChanged(bool value)
    {
        VisualStateManager.GoToState(this, value is true ? "Selected" : "Normal");
    }
}