namespace BetApp.Maui.Views.Controls;

public partial class TabBarItem : ContentView
{
    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TabBarItem), false, BindingMode.OneWay, propertyChanged: OnIsSelectedChanged);

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public event EventHandler Clicked { add => button.Clicked += value; remove => button.Clicked -= value; }


    public TabBarItem()
	{
		InitializeComponent();
	}


    private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var item = bindable as TabBarItem;

        VisualStateManager.GoToState(item, newValue is true ? "Selected" : "Normal");
    }
}
